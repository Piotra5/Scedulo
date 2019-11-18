using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Services;
using Scedulo.Shared.Models.ServicePermissions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.ServicePermissions
{
    public class ServicesPermissionService : IServicesPermissionService
    {
        private readonly ApplicationDbContext _context;

        #region ServicesPermissionService()
        public ServicesPermissionService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetListOfAllServicesPermissionsAsync()
        public async Task<List<ServicePermissionViewModel>> GetListOfAllRolesPermissionsToServices()
        {
            var servicePermissions = await _context.ServicePermissions
                .Select(p => new ServicePermissionViewModel
                {
                    Id = p.Id.ToString(),
                    RolePermissionId = p.RolePermissionId,
                    ServiceId = p.ServiceId
                })
                .ToListAsync();
            return servicePermissions;
        }
        #endregion

        #region GetServicePermissionAsync()
        public async Task<ServicePermissionViewModel> GetServicePermissionByIdAsync(string id)
        {
            var permission = await _context.ServicePermissions
                .Select(p => new ServicePermissionViewModel
                { 
                    Id = p.Id.ToString(),
                    RolePermissionId = p.RolePermissionId,
                    ServiceId = p.ServiceId 
                })
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();
            return permission;
        }
        #endregion

        #region AddServicePermissionAsync()
        public async Task<string> AddServicePermissionAsync(AddServicePermissionViewModel newPermission)
        {
            var id = new Guid();
            await _context.ServicePermissions.AddAsync(
                 new PermissionToService
                 {
                     Id = id,
                     RolePermissionId = newPermission.RolePermissionId,
                     ServiceId = newPermission.ServiceId
                 }
            );
            var saveResult = await _context.SaveChangesAsync();
            if (saveResult == 1)
            {
                return id.ToString();
            }
            return null;
        }
        #endregion

        #region DeleteServicePermissionAsync()
        public async Task<bool> DeleteServicePermissionAsync(string id)
        {
            var deleted = false;
            var permission = await _context.ServicePermissions
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (permission != null)
            {
                _context.Remove(permission);
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

        #region UpdateServicePermissionAsync()
        public async Task<bool> UpdateServicePermissionAsync(string id, ServicePermissionViewModel changedPermission)
        {
            var permission = await _context.ServicePermissions
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (permission != null)
            {
                permission.RolePermissionId = changedPermission.RolePermissionId;
                permission.ServiceId = changedPermission.ServiceId;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion


        public async Task<List<ServicePermissionViewModel>> GetPermissionsdByRoleIdAsync(string id)
        {
            var permissions = await _context.ServicePermissions
                .Select(p => new ServicePermissionViewModel
                {
                    Id = p.Id.ToString(),
                    RolePermissionId = p.RolePermissionId,
                    ServiceId = p.ServiceId
                })
                .Where(x => x.RolePermissionId == id)
                .ToListAsync();

            return permissions;
        }

        public async Task<List<ServicePermissionViewModel>> GetPermissionsByServiceIdAsync(string id)
        {
            var permissions = await _context.ServicePermissions
                .Select(p => new ServicePermissionViewModel
                {
                    Id = p.Id.ToString(),
                    RolePermissionId = p.RolePermissionId,
                    ServiceId = p.ServiceId
                })
                .Where(x => x.ServiceId == id)
                .ToListAsync();

            return permissions;
        }
    }
}
