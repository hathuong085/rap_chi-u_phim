using Cimena.BAL.INTERFACE;
using Cimena.Domain.Responses.Room;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RoomController:ControllerBase
    {
        private readonly IRoomSevice roomSevice;

        public RoomController(IRoomSevice roomSevice)
        {
            this.roomSevice = roomSevice;
        }
        [HttpGet]
        [Route("/api/Room/ShowingNow/")]
        public Task<IEnumerable<RoomNow>> ShowingNow()
        {
            return roomSevice.ShowingRoomNow();
        }
    }
}
