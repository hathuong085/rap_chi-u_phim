using Cimena.BAL.INTERFACE;
using Cimena.Domain.Requests.Film;
using Cimena.Domain.Responses.Film;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController
    {
        //private readonly ILogger<DepartmentController> _logger;
        private readonly IFilmService filmService;

        public FilmController(IFilmService filmService)
        {
            this.filmService = filmService;
        }
        [HttpGet]
        [Route("/api/film/GetfilmsByrate")]
        public async Task<IEnumerable<Film>> GetfilmsByrate()
        {
            return await filmService.Getfilmsbyrate();
        }
        [HttpGet]
        [Route("/api/Home/FilmToDays")]
        public async Task<IEnumerable<FilmToDay>> GetFilmToDays()
        {
            return await filmService.GetFilmToDays();
        }
        [HttpGet]
        [Route("/api/Films/Category/{id}")]
        public async Task<IEnumerable<Film>> GetFilmByCateFilmId(int id)
        {
            return await filmService.GetFilmByCateFilmId(id);
        }
        [HttpPost]
        [Route("/api/Home/ShowingsOfFilmOfDay")]
        public async Task<ShowingsOfFilmOfDay> Get(ShowingsOfFilmOfDayRequeste requests)
        {
            return await filmService.Get(requests);
        }
        [HttpGet]
        [Route("/api/Home/Film")]
        public async Task<IEnumerable<Film>> Home()
        {
            return await filmService.Homefilms();
        }
        [HttpPost]
        [Route("/api/Film/Create")]
        public async Task<SaveFilmResult> CreateFilm(CreateFilmRequest film)
        {
            return await filmService.CreateFilm(film);
        }
        [HttpPost]
        [Route("/api/Film/Update")]
        public async Task<SaveFilmResult> UpdateFilm(UpdateFilmRequest film)
        {
            return await filmService.UpdateFilm(film);
        }
        [HttpDelete]
        [Route("/api/Film/Delete/{id}")]
        public async Task<SaveFilmResult> DeleteFilm(int id)
        {
            return await filmService.DeleteFilm(id);
        }
        [HttpGet]
        [Route("/api/Film/Get/{id}")]
        public async Task<Film> Get(int id)
        {
            return await filmService.Get(id);
        }
        [HttpGet]
        [Route("/api/film/getfilmscreened/{id}")]
        public async Task<IEnumerable<Film>> GetFilmScreened(int id)
        {
            return await filmService.GetFilmScreened(id);
        }
        [HttpGet]
        [Route("/api/film/GetfilmUpComing/{id}")]
        public async Task<IEnumerable<Film>> GetfilmUpComing(int id)
        {
            return await filmService.GetfilmUpComing(id);
        }
        [HttpGet]
        [Route("/api/film/GetFilmNowShowing/{id}")]
        public async Task<IEnumerable<Film>> GetFilmNowShowing(int id)
        {
            return await filmService.GetFilmNowShowing(id);
        }

        [HttpPost]
        [Route("/api/film/GetFilmsOfDay")]
        public async Task<IEnumerable<Film>> GetFilmsOfDay(DayRequests day)
        {
            return await filmService.GetFilmsOfDay(day);
        }
        [HttpGet]
        [Route("/api/film/GetfilmsNew")]
        public async Task<IEnumerable<Film>> GetfilmsNew()
        {
            return await filmService.GetFilmsNew();
        }
        [HttpGet]
        [Route("/api/film/GetfilmsNowComing")]
        public async Task<IEnumerable<Film>> GetfilmsNowComing()
        {
            return await filmService.GetFilmsNowComing();
        }
        [HttpPost]
        [Route("/api/film/Searchfilm")]
        public async Task<IEnumerable<Film>> Searchfilm(KeySearch Key)
        {
            return await filmService.Searchfilm(Key);
        }
        [HttpPost]
        [Route("/api/film/GetFilmsByPeriod")]
        public async Task<IEnumerable<Film>> GetFilmsByPeriod(SeacrhDayRequests requests)
        {
            return await filmService.GetFilmsByPeriod(requests);
        }
        [HttpPost]
        [Route("/api/Film/rating")]
        public async Task<SaveRateResult> Ratefilm(CreateRateRequest film)
        {
            return await filmService.Ratefilm(film);
        }

    }
}
