using Cinema.Web.Models.Order;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class OrderController:Controller
    {
        [HttpPost]
        [Route("/Order/Create/")]
        public JsonResult CreateOrder([FromBody] OrderRequests model)
        {
            var result = new CreateOrderResult();
            result = ApiHelper<CreateOrderResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/order/save",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
