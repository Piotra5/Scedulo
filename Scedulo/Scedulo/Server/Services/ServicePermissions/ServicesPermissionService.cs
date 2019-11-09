using Scedulo.Server.Data;
using Scedulo.Server.Data.Models.Services;
using Scedulo.Shared.Models.ServicePermission;
using System;
using System.Collections.Generic;
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

        #region AddServicePermissionAsync()
        public Task<bool> AddServicePermissionAsync(AddServicePermssionViewModel newService)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DeleteServicePermissionAsync()
        public Task<bool> DeleteServicePermissionAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetListOfAllServicesPermissionsAsync()
        public Task<List<RoleServicePermission>> GetListOfAllServicesPermissionsAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetServicePermissionAsync()
        public Task<RoleServicePermission> GetServicePermissionAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UpdateServicePermissionAsync()
        public Task<bool> UpdateServicePermissionAsync(string id, ServicePermissionViewModel changedService)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
