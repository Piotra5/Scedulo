using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Employees;
using Scedulo.Shared.Models.EmployeePermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Permissions
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly ApplicationDbContext _context;

        #region EmployeePermissionService()
        public RolePermissionService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddPermissionAsync()
        public async Task<bool> AddPermissionAsync(RolePermission permission)
        {
            permission.Id = Guid.NewGuid();
            _context.RolePermissions.Add(permission);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeletePermssionAsync()
        public async Task<bool> DeletePermssionAsync(string id)
        {
            var deleted = false;
            var employee = await _context.RolePermissions
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (employee != null)
            {
                _context.Remove(employee);
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

        #region GetListOfAllPermissionsAsync()
        public async Task<List<RolePermissionViewModel>> GetListOfAllPermissionsAsync()
        {
            var permissions = await _context.RolePermissions
                .Select( role => new RolePermissionViewModel
                { 
                    Id = role.Id.ToString(),
                    EmployeeId = role.EmployeeId,
                    ExpiringDate = role.ExpiringTime,
                    RoleId = role.EmplyoeeRoleId
                })
                .ToListAsync();
            //var permissionsList = new EmployeePermissionsListModel();

            //foreach (var permission in permissions)
            //{
            //    permissionsList.Permissions.Add(new RolePermissionViewModel
            //    {
            //        Id = permission.Id.ToString(),
            //        EmployeeId = permission.EmployeeId,
            //        RoleId = permission.RoleId,
            //        ExpiringDate = permission.ExpiringDate
            //    });
            //}
            return permissions;
        }
        #endregion

        #region GetPermissionAsync()
        public async Task<RolePermissionViewModel> GetPermissionByIdAsync(string passedID)
        {
            var id = new Guid(passedID);
            var permission = await _context.RolePermissions
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            var permissionView = new RolePermissionViewModel
            {
                Id = permission.Id.ToString(),
                EmployeeId = permission.EmployeeId,
                RoleId = permission.EmplyoeeRoleId,
                ExpiringDate = permission.ExpiringTime,
            };

            return permissionView;
        }
        #endregion


        #region UpdatePermissionAsync()
        public async Task<bool> UpdatePermissionAsync(string passedID, RolePermissionModel changedPermission)
        {
            var id = new Guid(passedID);
            var permission = await _context.RolePermissions
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            if (permission != null)
            {
                permission.EmplyoeeRoleId = changedPermission.RoleId;
                permission.EmployeeId = changedPermission.EmployeeId;
                permission.ExpiringTime = changedPermission.ExpiringDate;
            }
            else { return false; }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion
    }
}
