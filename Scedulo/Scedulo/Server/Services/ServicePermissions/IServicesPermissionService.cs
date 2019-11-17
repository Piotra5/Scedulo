//using Scedulo.Server.Data.Entities.Services;
//using Scedulo.Shared.Models.ServicePermissions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Scedulo.Server.Services.ServicePermissions
//{
//    public interface IServicesPermissionService
//    {
//        Task<RoleServicePermssion> GetServicePermissionByIdAsync(string id);
//        Task<List<RoleServicePermssion>> GetListOfAllServicesPermissionsAsync();
//        Task<List<ServicePermissionViewModel>> GetPermissionsdByRoleIdAsync(string id);
//        Task<List<ServicePermissionViewModel>> GetPermissionsByServiceIdAsync(string id);
//        Task<string> AddServicePermissionAsync(AddServicePermissionViewModel newService);
//        Task<bool> DeleteServicePermissionAsync(string id);
//        Task<bool> UpdateServicePermissionAsync(string id, ServicePermissionViewModel changedService);
//    }
//}
