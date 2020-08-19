using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL
{
    public class RoomSevice : IRoomSevice
    {
        private readonly IRoomRepository roomRepository;

        public RoomSevice(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public Task<IEnumerable<RoomNow>> ShowingRoomNow()
        {
            return roomRepository.ShowingRoomNow();
        }
    }
}
