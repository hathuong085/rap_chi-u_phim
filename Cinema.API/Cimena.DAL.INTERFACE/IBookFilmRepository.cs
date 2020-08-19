using Cimena.Domain.Requests.BookFilm;
using Cimena.Domain.Responses.BookFilm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL.INTERFACE
{
    public interface IBookFilmRepository
    {
        Task<BookFilmResult> CreateBookFilm(BookFilmRequests request);
    }
}
