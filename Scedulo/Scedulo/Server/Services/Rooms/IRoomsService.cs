using Scedulo.Server.Data.Entities.Rooms;
using Scedulo.Shared.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Rooms
{
    public interface IRoomsService
    {
        Task<Room> GetRoomAsync(string id);
        Task<List<Room>> GetListOfAllRoomsAsync();
        Task<string> AddRoomAsync(AddRoomViewModel newRoom);
        Task<bool> DeleteRoomAsync(string id);
        Task<bool> UpdateRoomAsync(string id, RoomViewModel changedRoom);
    }
}
