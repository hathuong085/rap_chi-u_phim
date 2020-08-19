using Cinema.Web.Models.CategoryFilm;
using Cinema.Web.Models.Film;
using Cinema.Web.Models.Showing;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class ShowingController : Controller
    {
        [Route("/Showing/DeleteByTime")]
        public JsonResult DeleteByTime()
        {
            var message = new MessageSuccess();
            message = ApiHelper<MessageSuccess>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/DeleteByTime", "DELETE");
            return Json(new { message });
        }

        [Route("/Showing/DescriptionShowing/{id}")]
        public JsonResult DescriptionShowing(int id)
        {
            var descriptionShowing = new DescriptionShowing();
            descriptionShowing = ApiHelper<DescriptionShowing>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/Description/{id}");
            return Json(new { descriptionShowing });
        }
        [Route("/showing/seats/{id}")]
        public JsonResult Seats(int id)
        {
            var seats = new List<Seat>();
            seats = ApiHelper<List<Seat>>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/Seats/{id}");
            return Json(new { seats });
        }

        public JsonResult Top7DatesShow()
        {
            var days = new List<Dayshow>();
            days = ApiHelper<List<Dayshow>>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/Top7DatesShow");
            return Json(new { days });
        }
        /// <summary>
        /// Tìm kiếm cấc ngy có xuất chiếu trong 1 khoảng thời gian
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SearchDayshowByPeriod([FromBody] SearchDayRequests model)
        {
            var days = new List<Dayshow>();
            days = ApiHelper<List<Dayshow>>.HttpPostAsync($"{Helper.ApiUrl}api/Showing/SearchDayshowByPeriod", model);
            return Json(new { days });
        }
        /// <summary>
        /// Quản lý tất cả các xuất chiếu
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var showings = new List<AllDesShowing>();
            showings = ApiHelper<List<AllDesShowing>>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/GetAllShowing");
            ViewBag.Title = "Quản lý xuất chiếu";
            ViewBag.Showings = showings;
            return View();
        }
        public IActionResult Upcoming()
        {
            var showings = new List<AllDesShowing>();
            showings = ApiHelper<List<AllDesShowing>>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/GetAllShowing");
            ViewBag.Title = "Quản lý xuất chiếu";
            ViewBag.Showings = showings;
            return View();
        }
        public IActionResult AddShowingOfFilmNew()
        {
            ViewBag.Title = "Thêm xuất chiếu phim";
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/film/GetfilmsNew");
            List<CategoryFilm> listcategory = new List<CategoryFilm>();
            for (int i = 0; i < films.Count; i++)
            {
                var category = new CategoryFilm();
                category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{films[i].CategoryId}");
                listcategory.Add(category);
            }
            ViewBag.listcategory = listcategory;
            ViewBag.Films = films;
            return View();
        }
        public IActionResult AddShowingOfNowComing()
        {
            ViewBag.Title = "Thêm xuất chiếu phim";
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/film/GetfilmsNowComing");
            List<CategoryFilm> listcategory = new List<CategoryFilm>();
            for (int i = 0; i < films.Count; i++)
            {
                var category = new CategoryFilm();
                category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{films[i].CategoryId}");
                listcategory.Add(category);
            }
            ViewBag.listcategory = listcategory;
            ViewBag.Films = films;
            return View();
        }
        [HttpPost]
        public JsonResult TimeEmptyByRoomDay([FromBody] TimeRequests model)
        {
            List<TimeResult> results = new List<TimeResult>();
            results = ApiHelper<List<TimeResult>>.HttpPostAsync($"{Helper.ApiUrl}api/Showing/TimeEmptyByRoomDay", model);
            return Json(new { results });
        }
        [HttpPost]
        [Route("/Showing/Create/")]
        public JsonResult Create([FromBody] CreateShowingRequests model)
        {
            var result = new CreateShowingResult();
            result = ApiHelper<CreateShowingResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/Showing/Create",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
