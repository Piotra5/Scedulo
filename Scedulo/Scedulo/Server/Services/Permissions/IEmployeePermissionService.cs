using Scedulo.Server.Data.Entities.Employees;
using Scedulo.Shared.Models.EmployeePermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Permissions
{
    public interface IEmployeePermissionService
    {
        Task<EmployeePermissionsListModel> GetListOfAllPermissionsAsync();
        Task<EmployeePermissionViewModel> GetPermissionByIdAsync(string Id);
        Task<bool> AddPermissionAsync(EmployeePermission permission);
        //Task<Guid> GetPermissionsIdByRoleIdAsync(string id);
        //Task<Guid> GetPermissionsIdByServiceIdAsync(string id);
        Task<bool> DeletePermssionAsync(string id);
        Task<bool> UpdatePermissionAsync(string id, AddEmployeePermissionModel changedPermission);
    }
}
