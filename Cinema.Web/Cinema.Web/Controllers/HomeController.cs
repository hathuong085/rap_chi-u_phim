using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cinema.Web.Models;
using Cinema.Web.Ultilities;
using Cinema.Web.Models.Film;
using Cinema.Web.Models.Showing;
using Cinema.Web.Models.Event;

namespace Cinema.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HomeFilm()
        {
            ViewBag.Title = "Cinema NPT";
            return View();
        }
        public IActionResult Demo()
        {
            ViewBag.Title = "Cinema NPT";
            var banner = new List<EventDelete>();
            banner = ApiHelper<List<EventDelete>>.HttpGetAsync($"{Helper.ApiUrl}api/event/gets");
            if (banner != null)
            {
                ViewBag.banners = banner;
            }
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/Home/Film");
            if (films != null)
            {
                ViewBag.films = films;
            }
            return View();
        }
        
        public IActionResult Film(int id)
        {
            ViewBag.Title = "Cinema NPT";
            ViewBag.FilmId = id;
            var dayshows = new List<Dayshow>();
            dayshows = ApiHelper<List<Dayshow>>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/DayShowOfFilm/{id}");
            ViewBag.dayshows = dayshows;
            return View();
        }
        public JsonResult DayShowOfFilm(int id)
        {
            var dayshows = new List<Dayshow>();
            dayshows = ApiHelper<List<Dayshow>>.HttpGetAsync($"{Helper.ApiUrl}api/Showing/DayShowOfFilm/{id}");
            return Json(new { dayshows });
        }
        [HttpPost]
        public JsonResult ScreeningFilmOfDate([FromBody] ShowingOfFilmOfDayRequests model)
        {
            var timeshows = new List<TimeShow>();
            timeshows = ApiHelper<List<TimeShow>>.HttpPostAsync($"{Helper.ApiUrl}api/Showing/ScreeningFilmOfDate",model);
            return Json(new { timeshows });
        }
        public JsonResult Gets()
        {
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/Home/Film");
            return Json(new { films });
        }
        [HttpPost]
        public JsonResult GetFilmsOfDay([FromBody] DayRequests day)
        {
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpPostAsync($"{Helper.ApiUrl}api/film/GetFilmsOfDay",day);
            return Json(new { films });
        }
        public IActionResult FilmOfDate()
        {
            return View();
        }
    }
}
