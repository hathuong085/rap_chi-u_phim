using System;
using System.ComponentModel.DataAnnotations;

namespace Cimena.Domain.Requests.Film
{
    public class CreateRateRequest
    {
        [Required]
        public int FilmId { get; set; }
       
        public string Rate { get; set; }
    }
}
