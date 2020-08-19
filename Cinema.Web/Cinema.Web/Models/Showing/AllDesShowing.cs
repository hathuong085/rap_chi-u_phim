using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Showing
{
    public class AllDesShowing
    {
        public int ShowingId { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string StartTime { get; set; }
        public string Dayshow { get; set; }
        public int NumberChairOn { get; set; }
        public string RoomName { get; set; }
        public int PriceTicket { get; set; }
        public int Status { get; set; }

        public int Revenue()
        {
            return NumberChairOn * PriceTicket;
        }
    }
}
