using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.Film
{
    public class UpdateFilmRequest : CreateFilmRequest
    {
        public int FilmId { get; set; }
    }
}
