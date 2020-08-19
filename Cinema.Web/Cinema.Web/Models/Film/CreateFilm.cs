using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Film
{
    public class CreateFilm
    {
        public string FilmName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkTrailer { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
