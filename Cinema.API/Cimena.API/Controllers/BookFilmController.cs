using Cimena.BAL.INTERFACE;
using Cimena.Domain.Requests.BookFilm;
using Cimena.Domain.Responses.BookFilm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookFilmController
    {
        private readonly IBookFilmService bookFilmService;

        public BookFilmController(IBookFilmService bookFilmService)
        {
            this.bookFilmService = bookFilmService;
        }
        [HttpPost]
        [Route("/api/BookFilm/Create/")]
        public Task<BookFilmResult> Create(BookFilmRequests request)
        {
            return bookFilmService.CreateBookFilm(request);
        }
    }
}
