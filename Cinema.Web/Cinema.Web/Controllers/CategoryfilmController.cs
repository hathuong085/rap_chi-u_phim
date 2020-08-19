using Cinema.Web.Models.CategoryFilm;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class CategoryfilmController : Controller
    {
        public IActionResult Categoryfilm()
        {
            ViewBag.Title = "Cinema NPT";
            return View();
        }
        public JsonResult Gets()
        {
            var categories = new List<CategoryFilmResult>();
            categories = ApiHelper<List<CategoryFilmResult>>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/Gets");
            return Json(new { categories });
        }
        [Route("/CategoryFilm/Get/{id}")]
        public JsonResult Get(int id)
        {
            var category = new CategoryFilm();
            category = ApiHelper<CategoryFilm>.HttpGetAsync($"{Helper.ApiUrl}api/CategoryFilm/GetbyCateId/{id}");
            return Json(new { category });
        }
    }
}
