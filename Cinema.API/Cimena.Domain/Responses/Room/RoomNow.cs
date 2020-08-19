using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Responses.Room
{
    public class RoomNow
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int TotalSeat { get; set; }
        public int NumberChairOn { get; set; }
        public string FilmName { get; set; }
        public string TimeName { get; set; }
        public string Status { get; set; }
        public DateTime Dayshow { get; set; }
    }
}
