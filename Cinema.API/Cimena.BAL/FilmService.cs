using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.Film;
using Cimena.Domain.Responses.Film;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimena.BAL
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        public Task<SaveFilmResult> CreateFilm(CreateFilmRequest film)
        {
            return filmRepository.CreateFilm(film);
        }

        public Task<SaveFilmResult> DeleteFilm(int filmId)
        {
            return filmRepository.DeleteFilm(filmId);
        }

        public Task<ShowingsOfFilmOfDay> Get(ShowingsOfFilmOfDayRequeste requests)
        {
            return filmRepository.GetFilmsOfDay(requests);
        }

        public Task<Film> Get(int filmid)
        {
            return filmRepository.Get(filmid);
        }

        public Task<IEnumerable<Film>> GetFilmByCateFilmId(int cateid)
        {
            return filmRepository.GetFilmByCateFilmId(cateid);
        }

        /// <summary>
        /// lấy ra các phim đã chiếu của 1 loại phim
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public Task<IEnumerable<Film>> GetFilmScreened(int cateid)
        {
            return filmRepository.GetFilmScreened(cateid);
        }

        public Task<IEnumerable<FilmToDay>> GetFilmToDays()
        {
            return filmRepository.GetFilmsToDay();
        }

        public Task<IEnumerable<Film>> GetfilmUpComing(int cateid)
        {
            return filmRepository.GetfilmUpComing(cateid);
        }
        public Task<IEnumerable<Film>> GetFilmNowShowing(int cateid)
        {
            return filmRepository.GetFilmNowShowing(cateid);
        }

        public Task<IEnumerable<Film>> Homefilms()
        {
            return filmRepository.Homefilms();
        }

        public Task<SaveFilmResult> UpdateFilm(UpdateFilmRequest film)
        {
            return filmRepository.UpdateFilm(film);
        }
        public Task<IEnumerable<Film>> GetFilmsOfDay(DayRequests day)
        {
            return filmRepository.GetFilmsOfDay(day);
        }
        public Task<IEnumerable<Film>> Getfilmsbyrate()
        {
            return filmRepository.Getfilmsbyrate();
        }

        public Task<IEnumerable<Film>> Searchfilm(KeySearch Key)
        {
            return filmRepository.Searchfilm(Key);
        }
        public Task<IEnumerable<Film>> GetFilmsByPeriod(SeacrhDayRequests requests)
        {
            return filmRepository.GetFilmsByPeriod(requests);
        }

        public Task<IEnumerable<Film>> GetFilmsNew()
        {
            return filmRepository.GetFilmsNew();
        }

        public Task<IEnumerable<Film>> GetFilmsNowComing()
        {
            return filmRepository.GetFilmsNowComing();
        }
        public Task<SaveRateResult> Ratefilm(CreateRateRequest film)
        {
            return filmRepository.Ratefilm(film);
        }
    }
}
