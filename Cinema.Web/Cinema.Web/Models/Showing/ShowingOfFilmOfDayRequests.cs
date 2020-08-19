using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Showing
{
    public class ShowingOfFilmOfDayRequests
    {
        public int FilmId { get; set; }
        public string DayShow { get; set; }
    }
}
