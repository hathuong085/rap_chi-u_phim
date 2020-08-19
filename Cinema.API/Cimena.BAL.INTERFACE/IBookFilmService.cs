using Cimena.Domain.Requests.BookFilm;
using Cimena.Domain.Responses.BookFilm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL.INTERFACE
{
   public interface IBookFilmService
    {
        Task<BookFilmResult> CreateBookFilm(BookFilmRequests request);
    }
}
