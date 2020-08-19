using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.Film;
using Cimena.Domain.Requests.ShowFilm;
using Cimena.Domain.Responses.Showing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL
{
    public class ShowingService : IShowingService
    {
        private readonly IShowingRepository showingRepository;

        public ShowingService(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }

        public Task<IEnumerable<Dayshow>> DayShowOfFilm(int id)
        {
            return showingRepository.DayShowOfFilm(id);
        }

        public Task<MessageSuccess> DeleteShowingByTime()
        {
            return showingRepository.DeleteShowingByTime();
        }

        public Task<DescriptionShowing> DescriptionShowing(int id)
        {
            return showingRepository.DescriptionShowing(id);
        }

        public Task<IEnumerable<AllDesShwing>> GetAllShowing()
        {
            return showingRepository.GetAllShowing();
        }

        public Task<IEnumerable<TimeShow>> ScreeningFilmOfDate(ShowingOfFilmOfDayRequests request)
        {
            return showingRepository.ScreeningFilmOfDate(request);
        }

        public Task<IEnumerable<DayShow>> SearchDayshowByPeriod(SeacrhDayRequests requests)
        {
            return showingRepository.SearchDayshowByPeriod(requests);
        }

        public Task<IEnumerable<TimeResult>> TimeEmptybyRoomDay(TimeRequests requests)
        {
            return showingRepository.TimeEmptybyRoomDay(requests);
        }

        public Task<IEnumerable<Seat>> SeatsOfShowing(int id)
        {
            return showingRepository.SeatsOfShowing(id);
        }

        public Task<IEnumerable<DayShow>> Top7DatesShow()
        {
            return showingRepository.Top7DatesShow();
        }

        public Task<CreateShowingResult> CreateShowing(CreateShowingRequests requests)
        {
            return showingRepository.CreateShowing(requests);
        }
    }
}
