using Scedulo.Server.Data.Models.Employees;
using Scedulo.Shared.Models.EmployeePermission;
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
        //Task<Guid> GetPermissionIdByUserIdAsync(string id);
        Task<bool> DeletePermssionAsync(string id);
        Task<bool> UpdatePermissionAsync(string id, AddEmployeePermissionModel changedPermission);
    }
}
