using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.ShowFilm
{
   public class ShowingOfFilmOfDayRequests
    {
        public int FilmId { get; set; }
        public string DayShow { get; set; }
    }
}
