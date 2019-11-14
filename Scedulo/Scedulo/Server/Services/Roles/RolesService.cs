using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Employees;
using Scedulo.Shared.Models.EmployeeRoles;
using Scedulo.Shared.Models.RoomPermissions;
using Scedulo.Shared.Models.ServicePermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Roles
{
    public class RolesService : IRolesService
    {
        private readonly ApplicationDbContext _context;

        #region RolesService()
        public RolesService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetRoleById()
        public async Task<EmployeeRoleViewModel> GetRoleAsync(string id)
        {
            var role = await _context.EmployeeRoles
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            var roleViewModel = new EmployeeRoleViewModel
            {
                Id = role.Id.ToString(),
                Name = role.Name,
                Description = role.Description,

            };

            return roleViewModel;
        }
        #endregion

        #region GetListOfAllRolesAsync()
        public async Task<EmployeeRolesListViewModel> GetListOfAllRolesAsync()
        {
            var rolesList = await _context.EmployeeRoles
                .ToListAsync();
            var employeeRolesViewList = new EmployeeRolesListViewModel();
            //foreach (var service in role.AvailableServices)
            //{
            //    new ServicePermissionViewModel
            //    {
            //        Id = service.Id.ToString(),
            //        EmployeeRole = service.Se,

            //    }
            //}
            foreach (var role in rolesList)
            {
                var employeeRoleView = new EmployeeRoleViewModel
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Description = role.Description,
                };
                employeeRolesViewList.EmployeeRoles.Add(employeeRoleView);
            }
            return employeeRolesViewList;
        }
        #endregion

        #region AddRole()
        public async Task<bool> AddRoleAsync(EmployeeRole role)
        {
            role.Id = Guid.NewGuid();
            _context.EmployeeRoles.Add(role);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region UpdateEmployeeAsync()
        public async Task<bool> UpdateRoleAsync(string id, AddEmployeeRoleViewModel updatedRole)
        {
            var role = await _context.EmployeeRoles
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (role != null)
            {
                role.Name = updatedRole.Name;
                role.Description = updatedRole.Description;

            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteRole()
        public async Task<bool> DeleteRoleAsync(string id)
        {
            var deleted = false;
            var role = await _context.EmployeeRoles
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (role != null)
            {
                _context.Remove(role);
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

        //#region GetAllAvailableServicesForRole()
        //public async List<RoomPermissionViewModel> MyProperty { get; set; }
    }
}
