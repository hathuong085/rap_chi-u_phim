using Cimena.Domain.Requests.Film;
using Cimena.Domain.Responses.Film;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimena.DAL.INTERFACE
{
    public interface IFilmRepository
    {
        Task<IEnumerable<FilmToDay>> GetFilmsToDay();
        Task<IEnumerable<Film>> GetFilmByCateFilmId(int cateid);
        Task<Film> Get(int filmid);
        Task<ShowingsOfFilmOfDay> GetFilmsOfDay(ShowingsOfFilmOfDayRequeste requests);
        Task<IEnumerable<Film>> Homefilms();
        Task<SaveFilmResult> CreateFilm(CreateFilmRequest film);
        Task<SaveFilmResult> UpdateFilm(UpdateFilmRequest film);
        Task<SaveFilmResult> DeleteFilm(int filmId);

        Task<IEnumerable<Film>> GetFilmScreened(int cateid);
        Task<IEnumerable<Film>> GetFilmNowShowing(int cateid);
        Task<IEnumerable<Film>> GetfilmUpComing(int cateid);
        Task<IEnumerable<Film>> GetFilmsOfDay(DayRequests day);
        Task<IEnumerable<Film>> Getfilmsbyrate();
        Task<IEnumerable<Film>> GetFilmsNew();
        Task<IEnumerable<Film>> GetFilmsNowComing();
        Task<IEnumerable<Film>> Searchfilm(KeySearch Key);
        Task<IEnumerable<Film>> GetFilmsByPeriod(SeacrhDayRequests requests);
        Task<SaveRateResult> Ratefilm(CreateRateRequest film);
    }
}
