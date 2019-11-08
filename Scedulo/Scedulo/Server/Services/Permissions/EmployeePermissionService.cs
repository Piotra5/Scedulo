using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Shared.Models.EmployeePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Permissions
{
    public class EmployeePermissionService : IEmployeePermissionService
    {
        private readonly ApplicationDbContext _context;

        #region EmployeePermissionService()
        public EmployeePermissionService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddPermissionAsync()
        public async Task<bool> AddPermissionAsync(EmployeePermission permission)
        {
            permission.Id = Guid.NewGuid();
            _context.EmployeePermissions.Add(permission);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeletePermssionAsync()
        public async Task<bool> DeletePermssionAsync(string id)
        {
            var deleted = false;
            var employee = await _context.EmployeePermissions
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
        public async Task<EmployeePermissionsListModel> GetListOfAllPermissionsAsync()
        {
            var permissions = await _context.EmployeePermissions
                .ToListAsync();
            var permissionsList = new EmployeePermissionsListModel();

            foreach(var permission in permissions)
            {
                permissionsList.Permissions.Add(new EmployeePermissionViewModel
                {
                    Id = permission.Id.ToString(),
                    EmployeeId = permission.EmployeeId,
                    RoleId = permission.RoleId,
                    ExpiringDate = permission.ExpiringDate
                });
            }
            return permissionsList;
        }
        #endregion

        #region GetPermissionAsync()
        public async Task<EmployeePermissionViewModel> GetPermissionByIdAsync(string passedID)
        {
            var id = new Guid(passedID);
            var permission = await _context.EmployeePermissions
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            var permissionView = new EmployeePermissionViewModel
            {
                Id = permission.Id.ToString(),
                EmployeeId = permission.EmployeeId,
                RoleId = permission.RoleId,
                ExpiringDate = permission.ExpiringDate,
            };

            return permissionView;
        }
        #endregion


        #region UpdatePermissionAsync()
        public async Task<bool> UpdatePermissionAsync(string passedID, EmployeePermissionViewModel changedPermission)
        {
            var id = new Guid(passedID);
            var permission = await _context.EmployeePermissions
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            if (permission != null)
            {
                permission.RoleId = changedPermission.RoleId;
                permission.EmployeeId = changedPermission.EmployeeId;
                permission.ExpiringDate = changedPermission.ExpiringDate;
            }else { return false; }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion
    }
}
