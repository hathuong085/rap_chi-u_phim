using System;
namespace Cimena.Domain.Responses.Order
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ComboFoodId { get; set; }
        public int Count { get; set; }
        public int BookFilmId { get; set; }
    }
}
