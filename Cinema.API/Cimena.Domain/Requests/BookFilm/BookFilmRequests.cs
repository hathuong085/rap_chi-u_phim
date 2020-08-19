using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.BookFilm
{
   public class BookFilmRequests
    {
        public int CusId { get; set; }
        public int ShowingId { get; set; }
        public string ListChair { get; set; }
        public int  CountTicket { get; set; }
        public int PriceTiket { get; set; }
        public int TotalPrice { get; set; }
    }
}
