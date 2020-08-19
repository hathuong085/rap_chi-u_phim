using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.Event;
using Cimena.Domain.Responses.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public Task<SaveEventResult> CreateEvent(CreateEvent request)
        {
            return eventRepository.CreateEvent(request);
        }

        public Task<DeleteEventResult> DeleteEvent(int eventid)
        {
            return  eventRepository.DeleteEvent(eventid);
        }
        public Task<DeleteEventResult> RestoreEvent(int eventid)
        {
            return eventRepository.RestoreEvent(eventid);
        }

        public Task<Event> Get(int eventid)
        {
            return eventRepository.Get(eventid);
        }

        public Task<IEnumerable<EventDelete>> Gets()
        {
            return eventRepository.Gets();
        }

        public Task<SaveEventResult> UpdateEvent(Event request)
        {
            return eventRepository.UpdateEvent(request);
        }
    }
}
