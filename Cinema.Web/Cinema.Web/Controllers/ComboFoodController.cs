using Cinema.Web.Models.ComboFood;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class ComboFoodController : Controller
    {
        public IActionResult Index()
        {
            var comboFoods = new List<ComboFoodAll>();
            comboFoods = ApiHelper<List<ComboFoodAll>>.HttpGetAsync($"{Helper.ApiUrl}api/combofood/getall");
            return View(comboFoods);
        }
        [HttpPost]
        public JsonResult Save([FromBody] ComboFood combo)
        {
            var result = new SaveComboFoodResult();
            result = ApiHelper<SaveComboFoodResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/combofood/save",
                                                    combo
                                                );
            return Json(new { result });
        }
        
        public JsonResult Delete(int id)
        {
            var result = new DeleteCombooFoodResult();
            result = ApiHelper<DeleteCombooFoodResult>.HttpGetAsync($"{Helper.ApiUrl}api/combofood/delete/{id}","DELETE");
            return Json(new { result });
        }
        public JsonResult Restore(int id)
        {
            var result = new DeleteCombooFoodResult();
            result = ApiHelper<DeleteCombooFoodResult>.HttpGetAsync($"{Helper.ApiUrl}api/combofood/restore/{id}");
            return Json(new { result });
        }
        public JsonResult GetAll()
        {
            var comboFoods = new List<ComboFood>();
            comboFoods = ApiHelper<List<ComboFood>>.HttpGetAsync($"{Helper.ApiUrl}api/combofood/getall");
            return Json(new { comboFoods });
        }
        public JsonResult Gets()
        {
            var comboFoods = new List<ComboFood>();
            comboFoods = ApiHelper<List<ComboFood>>.HttpGetAsync($"{Helper.ApiUrl}api/combofood/gets");
            return Json(new { comboFoods });
        }
        public JsonResult Get(int id)
        {
            var comboFood = new ComboFood();
            comboFood = ApiHelper<ComboFood>.HttpGetAsync($"{Helper.ApiUrl}api/combofood/get/{id}");
            return Json(new { comboFood });
        }
    }
}
