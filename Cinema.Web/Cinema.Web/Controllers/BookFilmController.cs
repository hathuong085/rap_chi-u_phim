using Cinema.Web.Models.BookFilm;
using Cinema.Web.Models.ChairOn;
using Cinema.Web.Models.Customer;
using Cinema.Web.Models.Order;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class BookFilmController:Controller
    {
        [HttpPost]
        [Route("/BookFilm/Create/")]
        public JsonResult Create([FromBody] CreateBookFilmRequests model)
        {
            var result = new CreateChairOnResult();
            for(int i = 0; i < model.listseat.Length; i++)
            {
                var requests = new ChairOn()
                {
                    SeatId = model.listseat[i],
                    ShowingId = model.ShowingId
                };
                result = ApiHelper<CreateChairOnResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/chairOn/create",
                                                    requests
                                                );
                if (result.SeatId == 0)
                {
                    for(int j = 0; j < i; j++)
                    {
                        var requestsdel = new ChairOn()
                        {
                            SeatId = model.listseat[j],
                            ShowingId = model.ShowingId
                        };
                        DeleteSeat(requestsdel);
                    }
                    break;
                }
            }
            if (result.SeatId > 0)
            {
                Customer customer = new Customer()
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Mail = model.Mail
                };
                CustomerController customerController = new CustomerController();
                customerController.Create(customer, out int CustomerId);
                BookFilm bookFilm = new BookFilm()
                {
                    CusId = CustomerId,
                    ShowingId = model.ShowingId,
                    CountTicket = model.listseat.Length,
                    PriceTiket = model.TotalPriceTiket,
                    ListChair = model.ListNameSeat,
                    TotalPrice = model.TotalPriceOrder + model.TotalPriceTiket
                };
                CreateBookFilm(bookFilm, out int BookfilmId);
                if (model.listComboId.Length > 0)
                {
                    for (int i = 0; i < model.listComboId.Length; i++)
                    {
                        OrderRequests order = new OrderRequests()
                        {
                            OrderId = 0,
                            ComboFoodId = model.listComboId[i],
                            Count = model.ListCountCombo[i],
                            BookFilmId = BookfilmId
                        };
                        OrderController orderController = new OrderController();
                        orderController.CreateOrder(order);
                    }
                }
            }
            return Json(new { result });
        }
        [HttpPost]
        [Route("/ChairOn/DeleteSeat")]
        public JsonResult DeleteSeat([FromBody] ChairOn model)
        {
            var result = new DeleteChairOnResult();
            result = ApiHelper<DeleteChairOnResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/chairOn/delete",
                                                    model
                                                );
            return Json(new { result });
        }

        [HttpPost]
        [Route("/BookFilm/CreateBookFilm/")]
        public JsonResult CreateBookFilm(BookFilm model,out int BookFilmId)
        {
            var result = new BookFilmResult();
            result = ApiHelper<BookFilmResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/BookFilm/Create",
                                                    model
                                                );
            BookFilmId = result.BookFilmId;
            return Json(new { result });
        }
    }
}
