using Cimena.Domain.Responses.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL.INTERFACE
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomNow>> ShowingRoomNow();
    }
}
