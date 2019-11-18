using Scedulo.Server.Data.Entities.Employees;
using Scedulo.Shared.Models.EmployeePermissions;
using Scedulo.Shared.Models.EmployeeRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Permissions
{
    public interface IRolePermissionService
    {
        Task<List<RolePermissionViewModel>> GetListOfAllPermissionsAsync();
        Task<RolePermissionViewModel> GetPermissionByIdAsync(string Id);
        Task<bool> AddPermissionAsync(RolePermission permission);

        //Task<Guid> GetPermissionsIdByRoleIdAsync(string id);
        //Task<Guid> GetPermissionsIdByServiceIdAsync(string id);
        Task<bool> DeletePermssionAsync(string id);
        Task<bool> UpdatePermissionAsync(string id, RolePermissionModel changedPermission);
    }
}
