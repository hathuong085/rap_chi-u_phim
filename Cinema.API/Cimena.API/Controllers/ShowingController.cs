using Cimena.BAL.INTERFACE;
using Cimena.Domain.Requests.Film;
using Cimena.Domain.Requests.ShowFilm;
using Cimena.Domain.Responses.Showing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowingController
    {
        private readonly IShowingService showingService;

        public ShowingController(IShowingService showingService)
        {
            this.showingService = showingService;
        }
        [HttpDelete]
        [Route("/api/Showing/DeleteByTime/")]
        public async Task<MessageSuccess> DeleteFilm()
        {
            return await showingService.DeleteShowingByTime();
        }
        [HttpGet]
        [Route("/api/Showing/DayShowOfFilm/{id}")]
        public async Task<IEnumerable<Dayshow>> DayShowOfFilm(int id)
        {
            return await showingService.DayShowOfFilm(id);
        }
        [HttpPost]
        [Route("/api/Showing/ScreeningFilmOfDate")]
        public async Task<IEnumerable<TimeShow>> ScreeningFilmOfDate(ShowingOfFilmOfDayRequests request)
        {
            return await showingService.ScreeningFilmOfDate(request);
        }
        [HttpGet]
        [Route("/api/Showing/Seats/{id}")]
        public async Task<IEnumerable<Seat>> SeatsOfShowing(int id)
        {
            return await showingService.SeatsOfShowing(id);
        }
        [HttpGet]
        [Route("/api/Showing/Description/{id}")]
        public async Task<DescriptionShowing> DescriptionShowing(int id)
        {
            return await showingService.DescriptionShowing(id);
        }
        [HttpGet]
        [Route("/api/Showing/Top7DatesShow")]
        public async Task<IEnumerable<DayShow>> Top7DatesShow()
        {
            return await showingService.Top7DatesShow();
        }
        [HttpGet]
        [Route("/api/Showing/GetAllShowing")]
        public async Task<IEnumerable<AllDesShwing>> GetAllShowing()
        {
            return await showingService.GetAllShowing();
        }
        [HttpPost]
        [Route("/api/Showing/SearchDayshowByPeriod")]
        public async Task<IEnumerable<DayShow>> SearchDayshowByPeriod(SeacrhDayRequests requests)
        {
            return await showingService.SearchDayshowByPeriod(requests);
        }
        [HttpPost]
        [Route("/api/Showing/TimeEmptyByRoomDay")]
        public async Task<IEnumerable<TimeResult>> TimeEmptyByRoomDay(TimeRequests requests)
        {
            return await showingService.TimeEmptybyRoomDay(requests);
        }
        [HttpPost]
        [Route("/api/Showing/Create")]
        public async Task<CreateShowingResult> CreateFilm(CreateShowingRequests requests)
        {
            return await showingService.CreateShowing(requests);
        }
    }
}
