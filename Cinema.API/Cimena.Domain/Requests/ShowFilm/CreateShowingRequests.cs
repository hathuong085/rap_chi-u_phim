using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.ShowFilm
{
   public class CreateShowingRequests
    {
        public int FilmId { get; set; }
        public int TimeId { get; set; }
        public int RoomId { get; set; }
        public string DayShow { get; set; }
    }
}
