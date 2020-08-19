using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.BookFilm
{
    public class CreateBookFilmRequests
    {
        public int[] listseat { get; set; }
        public int ShowingId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int PriceTiket { get; set; }
        public int TotalPriceTiket { get; set; }
        public int TotalPriceOrder { get; set; }
        public string ListNameSeat { get; set; }
        public int[] listComboId { get; set; }
        public int[] ListCountCombo { get; set; }
    }
}
