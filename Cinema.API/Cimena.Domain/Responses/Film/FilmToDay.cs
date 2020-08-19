using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Responses.Film
{
    public class FilmToDay
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string LinkTrailer { get; set; }
        public int CategoryId { get; set; }

    }
}
