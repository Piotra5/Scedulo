using Scedulo.Server.Data.Models.Employees;
using Scedulo.Shared.Models.EmployeeRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Roles
{
    public interface IRolesService
    {
        Task<EmployeeRoleViewModel> GetRoleAsync(string id);
        Task<EmployeeRolesListViewModel> GetListOfAllRolesAsync();
        Task<bool> AddRoleAsync(EmployeeRole role);
        Task<bool> DeleteRoleAsync(string id);
        Task<bool> UpdateRoleAsync(string id, AddEmployeeRoleViewModel updatedRole);
    }
}
