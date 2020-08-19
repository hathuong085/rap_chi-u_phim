using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Film
{
    public class UpdateFilm : CreateFilm
    {
        public int FilmId { get; set; }
       
    }
}
