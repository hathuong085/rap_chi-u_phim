using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.CategoryFilm
{
    public class CategoryFilmResult
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CountUpcoming { get; set; }
        public int CountScreened { get; set; }
        public int CountNowShowing { get; set; }
    }
}
