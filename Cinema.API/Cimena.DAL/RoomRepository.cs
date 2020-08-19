using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.Room;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public async Task<IEnumerable<RoomNow>> ShowingRoomNow()
        {
            return await SqlMapper.QueryAsync<RoomNow>(cnn: conn, 
                                                       sql: "sp_ShowRoomNow", 
                                                       commandType: CommandType.StoredProcedure);
        }
    }
}
