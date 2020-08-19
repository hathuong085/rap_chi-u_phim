using Cimena.Domain.Requests.Event;
using Cimena.Domain.Responses.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL.INTERFACE
{
   public interface IEventRepository
    {
        Task<IEnumerable<EventDelete>> Gets();
        Task<Event> Get(int eventid);
        Task<SaveEventResult> CreateEvent(CreateEvent request);
        Task<SaveEventResult> UpdateEvent(Event request);
        Task<DeleteEventResult> DeleteEvent(int eventid);
        Task<DeleteEventResult> RestoreEvent(int eventid);
    }
}
