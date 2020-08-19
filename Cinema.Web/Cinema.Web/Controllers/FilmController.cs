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
    public class FilmController:Controller
    {
        public IActionResult FilmScreened(int id)
        {
            ViewBag.Title = "Film NPT";
            var category = new CategoryFilm();
            category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{id}");
            if (category != null)
            {
                ViewBag.Category = category;
            }
            List<Film> films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/film/getfilmscreened/{id}");
            ViewBag.CategoryId = id;
            return View(films);
        }
        public IActionResult FilmUpComing(int id)
        {
            ViewBag.Title = "Film NPT";
            var category = new CategoryFilm();
            category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{id}");
            if (category != null)
            {
                ViewBag.Category = category;
            }
            List<Film> films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/film/GetfilmUpComing/{id}");
            ViewBag.CategoryId = id;
            return View(films);
        }
        public IActionResult FilmNowShowing(int id)
        {
            ViewBag.Title = "Film NPT";
            var category = new CategoryFilm();
            category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{id}");
            if (category != null)
            {
                ViewBag.Category = category;
            }
            List<Film> films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/film/GetFilmNowShowing/{id}");
            ViewBag.CategoryId = id;
            return View(films);
        }
        [Route("/Film/Gets/{CateId}")]
        public JsonResult Gets(int CateId)
        {
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/Films/Category/{CateId}");
            return Json(new { films });
        }
        [HttpPost]
        [Route("/Film/Create/")]
        public JsonResult Create([FromBody] CreateFilm model)
        {
            var result = new CreateFilmResult();
            model.LinkTrailer = model.LinkTrailer.Substring(model.LinkTrailer.IndexOf("=") + 1);
            result = ApiHelper<CreateFilmResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/Film/Create",
                                                    model
                                                );
            return Json(new { result });
        }
        public JsonResult Get(int id)
        {
            var film = new Film();
            film = ApiHelper<Film>.HttpGetAsync($"{Helper.ApiUrl}api/Film/Get/{id}");
            return Json(new { film });
        }
        public IActionResult FilmShow(int id)
        {
            ViewBag.Title = "Film NPT";
            var category = new CategoryFilm();
            category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{id}");
            if (category != null)
            {
                ViewBag.Category = category;
            }
            ViewBag.FilmId = id;
            return View();
        }
        [HttpPost]
        [Route("/Film/Update/")]
        public JsonResult Update([FromBody] UpdateFilm model)
        {
            var result = new CreateFilmResult();
            model.LinkTrailer = model.LinkTrailer.Substring(model.LinkTrailer.IndexOf("=") + 1);
            result = ApiHelper<CreateFilmResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/Film/Update",
                                                    model
                                                );
            return Json(new { result });
        }

        public JsonResult GetsFilmTop()
        {
            var films= new List<Film>();
            films = ApiHelper<List<Film>>.HttpGetAsync($"{Helper.ApiUrl}api/film/GetfilmsByrate");
            return Json(new { films });
        }
         [HttpPost]
        public JsonResult SearchfilmByDay([FromBody] DayRequests model)
        {
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpPostAsync($"{Helper.ApiUrl}api/film/GetFilmsOfDay", model);
            return Json(new { films });
        }
        public IActionResult Search()
        {
            ViewBag.Title = "Cinema NPT";
            return View();
        }
        [HttpPost]
        public JsonResult Searchfilm([FromBody] KeySearch model)
        {
            var search = new List<Film>();
            search = ApiHelper<List<Film>>.HttpPostAsync($"{Helper.ApiUrl}api/Film/Searchfilm",model);
            return Json(new { search });
        }
        /// <summary>
        /// Tìm kiếm film trong 1 khoảng thời gian
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GesFilmByPeriod([FromBody] SearchDayRequests model)
        {
            var films = new List<Film>();
            films = ApiHelper<List<Film>>.HttpPostAsync($"{Helper.ApiUrl}api/film/GetFilmsByPeriod", model);
            return Json(new { films });
        }
    }
}
