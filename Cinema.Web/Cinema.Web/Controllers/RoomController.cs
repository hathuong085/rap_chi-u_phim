using Cinema.Web.Models.Room;
using Cinema.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class RoomController:Controller
    {
        [Route("/Room/ShowingNow")]
        public JsonResult ShowingRoomNow()
        {
            var rooms = new List<RoomNow>();
            rooms = ApiHelper<List<RoomNow>>.HttpGetAsync($"{Helper.ApiUrl}api/Room/ShowingNow");
            return Json(new { rooms });
        }
    }
}
