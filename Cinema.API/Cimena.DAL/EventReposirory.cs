using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.Event;
using Cimena.Domain.Responses.Event;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
   public class EventReposirory : BaseRepository, IEventRepository
    {
        public async Task<SaveEventResult> CreateEvent(CreateEvent request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@NameEvent", request.NameEvent);
            parameters.Add("@TitleEvent", request.TitleEvent);
            parameters.Add("@ImageEvent", request.ImageEvent);
            parameters.Add("@LinkEvent", request.LinkEvent);
           
            return (await SqlMapper.QueryFirstOrDefaultAsync<SaveEventResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_CreateEvent",
                            commandType: CommandType.StoredProcedure));
        }
        
        public async Task<DeleteEventResult> DeleteEvent(int eventid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EventId", eventid);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteEventResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_DeleteEventById",
                            commandType: CommandType.StoredProcedure);
        }
        public async Task<DeleteEventResult> RestoreEvent(int eventid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EventId", eventid);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteEventResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_RestoreEventById",
                            commandType: CommandType.StoredProcedure);
        }

        public async Task<Event> Get(int eventid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EventId", eventid);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Event>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetEventByEventId",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<EventDelete>> Gets()
        {
            return await SqlMapper.QueryAsync<EventDelete>(conn, "sp_GetEvents", CommandType.StoredProcedure);
        }

        public async Task<SaveEventResult> UpdateEvent(Event request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EventId", request.EventId);
            parameters.Add("@NameEvent", request.NameEvent);
            parameters.Add("@TitleEvent", request.TitleEvent);
            parameters.Add("@ImageEvent", request.ImageEvent);
            parameters.Add("@LinkEvent", request.LinkEvent);      
            return (await SqlMapper.QueryFirstOrDefaultAsync<SaveEventResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_UpdateEvent",
                            commandType: CommandType.StoredProcedure)); ;
        }
    }
}
