using Microsoft.AspNetCore.Mvc;
using Cinema.Web.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Web.Ultilities;

namespace Cinema.Web.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            var events = new List<EventDelete>();
            events = ApiHelper<List<EventDelete>>.HttpGetAsync($"{Helper.ApiUrl}api/event/gets");
           ;
            return View(events);
        }
        [HttpPost]
        [Route("/Event/Create/")]
        public JsonResult CreateEvent([FromBody] CreateEventResult model)
        {
            var result = new SaveEventResult();
            result = ApiHelper<SaveEventResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/event/create",
                                                    model
                                                );
            return Json(new { result });
        }
        [HttpPost]
        [Route("/Event/Update/")]
        public JsonResult UpdateEvent([FromBody] Event model)
        {
            var result = new SaveEventResult();          
            result = ApiHelper<SaveEventResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/event/update",
                                                    model
                                                );
            return Json(new { result });
        }
        public JsonResult Get(int id)
        {
            var isevent = new Event();
            isevent = ApiHelper<Event>.HttpGetAsync($"{Helper.ApiUrl}api/event/get/{id}");
            return Json(new { isevent });
        }
        public JsonResult Delete(int id)
        {
            var result = new DeleteEventResult();
            result = ApiHelper<DeleteEventResult>.HttpGetAsync($"{Helper.ApiUrl}api/event/delete/{id}","DELETE");
            return Json(new { result });
        }
        public JsonResult Restore(int id)
        {
            var result = new DeleteEventResult();
            result = ApiHelper<DeleteEventResult>.HttpGetAsync($"{Helper.ApiUrl}api/event/restore/{id}");
            return Json(new { result });
        }
    }
}
