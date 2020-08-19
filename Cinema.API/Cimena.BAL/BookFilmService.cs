using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.BookFilm;
using Cimena.Domain.Responses.BookFilm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL
{
    public class BookFilmService : IBookFilmService 
    {
        private readonly IBookFilmRepository bookFilmRepository;

        public BookFilmService(IBookFilmRepository bookFilmRepository)
        {
            this.bookFilmRepository = bookFilmRepository;
        }
        public Task<BookFilmResult> CreateBookFilm(BookFilmRequests request)
        {
            return bookFilmRepository.CreateBookFilm(request);
        }
    }
}
