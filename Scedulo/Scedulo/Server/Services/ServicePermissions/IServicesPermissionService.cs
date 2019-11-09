using Scedulo.Server.Data.Models.Services;
using Scedulo.Shared.Models.ServicePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.ServicePermissions
{
    public interface IServicesPermissionService
    {
        Task<RoleServicePermission> GetServicePermissionAsync(string id);
        Task<List<RoleServicePermission>> GetListOfAllServicesPermissionsAsync();
        Task<bool> AddServicePermissionAsync(AddServicePermssionViewModel newService);
        Task<bool> DeleteServicePermissionAsync(string id);
        Task<bool> UpdateServicePermissionAsync(string id, ServicePermissionViewModel changedService);
    }
}
