using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Showing
{
    public class CreateShowingRequests
    {
        public int FilmId { get; set; }
        public int TimeId { get; set; }
        public int RoomId { get; set; }
        public string DayShow { get; set; }
    }
}
