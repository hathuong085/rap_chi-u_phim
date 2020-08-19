using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Order
{
    public class OrderRequests
    {
        public int OrderId { get; set; }
        public int ComboFoodId { get; set; }
        public int Count { get; set; }
        public int BookFilmId { get; set; }
    }
}
