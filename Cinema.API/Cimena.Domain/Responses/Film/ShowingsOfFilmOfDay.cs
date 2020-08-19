using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Responses.Film
{
    public class ShowingsOfFilmOfDay
    {
        public int FilmId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string TotalSeat { get; set; }
        public string StartTime { get; set; }
        public string Dayshow { get; set; }
        public string PriceTicket { get; set; }
        public int Price { get; set; }
    }
}
