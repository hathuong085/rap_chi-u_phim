using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Responses.CategoryFilm

{
    public class CategoyryFilmResult
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CountUpcoming { get; set; }
        public int CountScreened{ get; set; }
        public int CountNowShowing { get; set; }
    }

}
