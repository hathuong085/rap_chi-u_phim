using Cimena.BAL.INTERFACE;
using Cimena.Domain.Requests.Event;
using Cimena.Domain.Responses.Event;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        [HttpGet]
        [Route("/api/event/gets")]
        public async Task<IEnumerable<EventDelete>> Gets()
        {
            return await eventService.Gets();
        }
        [HttpGet]
        [Route("/api/event/get/{id}")]
        public async Task<Event> Get(int id)
        {
            return await eventService.Get(id);
        }
        [HttpPost]
        [Route("/api/event/create")]
        public async Task<SaveEventResult> CreateEvent(CreateEvent request)
        {
            return await eventService.CreateEvent(request);
        }
        [HttpPost]
        [Route("/api/event/update")]
        public async Task<SaveEventResult> UpdateEvent(Event request)
        {
            return await eventService.UpdateEvent(request);
        }

        [HttpDelete]
        [Route("/api/event/delete/{id}")]
        public async Task<DeleteEventResult> DeleteEvent(int id)
        {
            return await eventService.DeleteEvent(id);
        }
        [HttpGet]
        [Route("/api/event/restore/{id}")]
        public async Task<DeleteEventResult> RestoreEvent(int id)
        {
            return await eventService.RestoreEvent(id);
        }
    }
}
