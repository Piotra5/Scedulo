//using Microsoft.EntityFrameworkCore;
//using Scedulo.Server.Data;
//using Scedulo.Server.Data.Entities.Services;
//using Scedulo.Shared.Models.ServicePermissions;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Scedulo.Server.Services.ServicePermissions
//{
//    public class ServicesPermissionService : IServicesPermissionService
//    {
//        private readonly ApplicationDbContext _context;

//        #region ServicesPermissionService()
//        public ServicesPermissionService(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        #endregion

//        #region GetListOfAllServicesPermissionsAsync()
//        public async Task<List<RoleServicePermssion>> GetListOfAllServicesPermissionsAsync()
//        {
//            var permissions = await _context.RoleServicePermission
//                .ToListAsync();
//            return permissions;
//        }
//        #endregion

//        #region GetServicePermissionAsync()
//        public async Task<RoleServicePermssion> GetServicePermissionByIdAsync(string id)
//        {
//            var permission = await _context.RoleServicePermission
//                .Where(x => x.Id.ToString() == id)
//                .SingleOrDefaultAsync();
//            return permission;
//        }
//        #endregion

//        #region AddServicePermissionAsync()
//        public async Task<string> AddServicePermissionAsync(AddServicePermissionViewModel newPermission)
//        {
//            var permission = new RoleServicePermssion
//            {
//                Id = Guid.NewGuid(),
//                ServiceRoleId = newPermission.ServiceRoleId,
//                ServiceId = newPermission.ServiceId
//            };

//            _context.RoleServicePermission.Add(permission);
//            var saveResult = await _context.SaveChangesAsync();
//            if(saveResult == 1)
//            {
//                return permission.Id.ToString();
//            }
//            return null;
//        }
//        #endregion

//        #region DeleteServicePermissionAsync()
//        public async Task<bool> DeleteServicePermissionAsync(string id)
//        {
//            var deleted = false;
//            var permission = await _context.RoleServicePermission
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

//        #region UpdateServicePermissionAsync()
//        public async Task<bool> UpdateServicePermissionAsync(string id, ServicePermissionViewModel changedPermission)
//        {
//            var permission = await _context.RoleServicePermission
//                .Where(x => x.Id.ToString() == id)
//                .SingleOrDefaultAsync();

//            if (permission != null)
//            {
//                permission.ServiceRoleId = changedPermission.ServiceRoleId;
//                permission.ServiceId = changedPermission.ServiceId;
//            }

//            var saveResult = await _context.SaveChangesAsync();
//            return saveResult == 1;
//        }
//        #endregion


//        public async Task <List<ServicePermissionViewModel>> GetPermissionsdByRoleIdAsync(string id)
//        {
//            var permissions = await _context.RoleServicePermission
//                .Where(x => x.ServiceRoleId == id)
//                .ToListAsync();
//            var list = new List<ServicePermissionViewModel>();
//            foreach (var permission in permissions)
//            {
//                var Permission = new ServicePermissionViewModel
//                {
//                    Id = permission.Id.ToString(),
//                    ServiceId = permission.ServiceId,
//                    ServiceRoleId = permission.ServiceRoleId

//                };
//                list.Add(Permission);
//            }
//            return list;
//        }

//        public async Task <List<ServicePermissionViewModel>> GetPermissionsByServiceIdAsync(string id)
//        {
//            var permissions = await _context.RoleServicePermission
//                .Where(x => x.ServiceId == id)
//                .ToListAsync();
//            var list = new List<ServicePermissionViewModel>();
//            foreach (var permission in permissions)
//            {
//                var Permission = new ServicePermissionViewModel
//                {
//                    Id = permission.Id.ToString(),
//                    ServiceId = permission.ServiceId,
//                    ServiceRoleId = permission.ServiceRoleId

//                };
//                list.Add(Permission);
//            }
//            return list;
//        }
//    }
//}
