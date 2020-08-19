using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.Film
{
    public class ShowingsOfFilmOfDayRequeste
    {
        public int FilmId { get; set; }
        public string day { get; set; }
        public int timeid { get; set; }
    }
}
