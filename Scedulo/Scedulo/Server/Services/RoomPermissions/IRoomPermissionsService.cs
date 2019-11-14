using Scedulo.Server.Data.Entities.Rooms;
using Scedulo.Shared.Models.RoomPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.RoomPermissions
{
    public interface IReservationsService
    {
        Task<RoleRoomPermission> GetPermissionByIdAsync(string id);
        Task<IEnumerable<RoleRoomPermission>> GetListOfAllPermissionsAsync();
        Task<List<RoomPermissionViewModel>> GetPermissionsByRoleIdAsync(string id);
        Task<List<RoomPermissionViewModel>> GetPermissionsByRoomIdAsync(string id);
        Task<string> AddPermissionAsync(AddRoomPermissionViewModel newRoomPermission);
        Task<bool> DeletePermissionAsync(string id);
        Task<bool> UpdatePermissionAsync(string id, RoomPermissionViewModel changedRoomPermission);
    }
}
