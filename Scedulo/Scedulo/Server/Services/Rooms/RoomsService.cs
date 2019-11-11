using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Models.Rooms;
using Scedulo.Shared.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Rooms
{
    public class RoomsService : IRoomsService
    {
        public readonly ApplicationDbContext _context;

        #region RommsService()
        public RoomsService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddRoomsAsync()
        public async Task<string> AddRoomAsync(AddRoomViewModel newRoom)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                Name = newRoom.Name,
                Description = newRoom.Description

            };

            _context.Rooms.Add(room);

            var saveResult = await _context.SaveChangesAsync();
            if (saveResult == 1)
                return room.Id.ToString();
            return null;
        }
        #endregion

        #region DeleteRoomsAsync()
        public async Task<bool> DeleteRoomAsync(string id)
        {
            var deleted = false;
            var room = await _context.Rooms
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (room != null)
            {
                _context.Remove(room);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
        #endregion

        #region GetListOfAllRoomsAsync()
        public async Task<List<Room>> GetListOfAllRoomsAsync()
        {
            var rooms = await _context.Rooms
                .ToListAsync();
            return rooms;
        }
        #endregion

        #region GetRoomAsync()
        public async Task<Room> GetRoomAsync(string id)
        {
            var room = await _context.Rooms
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            return room;
        }
        #endregion

        #region UpdateRoomsAsync()
        public async Task<bool> UpdateRoomAsync(string id, RoomViewModel changedRoom)
        {
            var room = await _context.Rooms
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (room != null)
            {
                room.Name = changedRoom.Name;
                room.Description = changedRoom.Description;
                _context.Update(room);

            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion
    }
}
