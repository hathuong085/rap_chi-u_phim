using Cimena.Domain.Responses.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL.INTERFACE
{
    public interface IRoomSevice
    {
        Task<IEnumerable<RoomNow>> ShowingRoomNow();
    }
}
