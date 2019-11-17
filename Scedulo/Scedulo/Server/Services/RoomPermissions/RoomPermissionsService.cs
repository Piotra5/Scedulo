//using Microsoft.EntityFrameworkCore;
//using Scedulo.Server.Data;
//using Scedulo.Server.Data.Entities.Rooms;
//using Scedulo.Shared.Models.RoomPermissions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Scedulo.Server.Services.RoomPermissions
//{
//    public class RoomPermissionsService : IRoomPermissionsService
//    {
//        private readonly ApplicationDbContext _context;

//        #region RoomPermissionsService()
//        public RoomPermissionsService(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        #endregion

//        #region AddRoomPermissionAsync()
//        public async Task<string> AddPermissionAsync(AddRoomPermissionViewModel newRoomPermission)
//        {
//            var permission = new RoleRoomPermission
//            {
//                Id = Guid.NewGuid(),
//                ServiceRoleId = newRoomPermission.ServiceRoleId,
//                RoomId = newRoomPermission.RoomId
//            };

//            _context.RoleRoomPermissions.Add(permission);
//            var saveResult = await _context.SaveChangesAsync();
//            if (saveResult == 1)
//            {
//                return permission.Id.ToString();
//            }
//            return null;
//        }
//        #endregion

//        #region DeleteRoomPermissionAsync()
//        public async Task<bool> DeletePermissionAsync(string id)
//        {
//            var deleted = false;
//            var permission = await _context.RoleRoomPermissions
//                .Where(x => x.Id.ToString() == id)
//                .SingleOrDefaultAsync();

//            if (permission != null)
//            {
//                _context.Remove(permission);
//                deleted = true;
//            }
//            else
//            {
//                deleted = false;
//            }

//            var saveResult = await _context.SaveChangesAsync();
//            return saveResult == 1 && deleted == true;
//        }
//        #endregion

//        #region GetListOfAllRoomsPermissionsAsync()
//        public async Task<IEnumerable<RoleRoomPermission>> GetListOfAllPermissionsAsync()
//        {
//            var permissions = await _context.RoleRoomPermissions
//                .ToListAsync();
//            return permissions;
//        }
//        #endregion

//        #region GetRoomsdByRoleIdAsync()
//        public async Task<List<RoomPermissionViewModel>> GetPermissionsByRoleIdAsync(string id)
//        {
//            var permissions = await _context.RoleRoomPermissions
//                .Where(x => x.ServiceRoleId == id)
//                .ToListAsync();
//            var list = new List<RoomPermissionViewModel>();
//            foreach (var permission in permissions)
//            {
//                var Permission = new RoomPermissionViewModel
//                {
//                    Id = permission.Id.ToString(),
//                    RoomId = permission.RoomId,
//                    ServiceRoleId = permission.ServiceRoleId

//                };
//                list.Add(Permission);
//            }
//            return list;
//        }
//        #endregion

//        #region GetRoomPermissionByIdAsync()
//        public async Task<RoleRoomPermission> GetPermissionByIdAsync(string id)
//        {
//            var guidId = new Guid(id);
//            var permission = await _context.RoleRoomPermissions
//                .Where(x => x.Id == guidId)
//                .SingleOrDefaultAsync();
//            return permission;
//        }
//        #endregion

//        #region GetRoomsByIdAsync()
//        public async Task<List<RoomPermissionViewModel>> GetPermissionsByRoomIdAsync(string id)
//        {
//            var permissions = await _context.RoleRoomPermissions
//                .Where(x => x.RoomId == id)
//                .ToListAsync();
//            var list = new List<RoomPermissionViewModel>();
//            foreach (var permission in permissions)
//            {
//                var Permission = new RoomPermissionViewModel
//                {
//                    Id = permission.Id.ToString(),
//                    RoomId = permission.RoomId,
//                    ServiceRoleId = permission.ServiceRoleId

//                };
//                list.Add(Permission);
//            }
//            return list;
//        }
//        #endregion

//        #region UpdateRoomPermissionAsync()
//        public async Task<bool> UpdatePermissionAsync(string id, RoomPermissionViewModel changedRoomPermission)
//        {
//            var permission = await _context.RoleServicePermission
//                .Where(x => x.Id.ToString() == id)
//                .SingleOrDefaultAsync();

//            if (permission != null)
//            {
//                permission.ServiceRoleId = changedRoomPermission.ServiceRoleId;
//                permission.ServiceId = changedRoomPermission.RoomId;
//            }

//            var saveResult = await _context.SaveChangesAsync();
//            return saveResult == 1;
//        }
//        #endregion
//    }
//}
