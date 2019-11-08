using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Server.Services.Employees;
using Scedulo.Server.Services.Permissions;
using Scedulo.Server.Services.Roles;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.EmployeePermission;
using Scedulo.Shared.Models.EmployeeRoles;

namespace Scedulo.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : Controller
    {

        private readonly IEmployeePermissionService _permissionService;
        //private readonly UserManager<ApplicationUser> _userManager;

        public PermissionsController(IEmployeePermissionService PermisionService)
        {
            _permissionService = PermisionService;
            //_employeeService = EmployeeService;
            //_rolesService = RolesService;
        }

        // GET api/permissions
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Employees = await _permissionService.GetListOfAllPermissionsAsync();
            return Ok(Employees);
        }

        // GET api/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _permissionService.GetPermissionByIdAsync(id);
            return Ok(employee);
        }

        //POST api/permissions
        [HttpPost]
        public async Task<IActionResult> AddPermmission([FromBody]AddEmployeePermissionModel newPermission)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
                return BadRequest(new AddingResult { Successful = false, Errors = modelErrors });
            }
            var permission = new EmployeePermission
            {
                Id = Guid.NewGuid(),
                EmployeeId = newPermission.EmployeeId,
                RoleId = newPermission.RoleId,
                ExpiringDate = newPermission.ExpiringDate
            };

            var successful = await _permissionService.AddPermissionAsync(permission);
            if (!successful)
            {
                return BadRequest("Could not add role.");
            }
            return Ok("Added permission: " + permission.Id);
        }

        //PUT api/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpPut]
        public async Task<IActionResult> EditPermission(string id, [FromBody]AddEmployeePermissionModel updatedRole)
        {
            var successful = await _permissionService
            .UpdatePermissionAsync(id, updatedRole);

            if (!successful)
            {
                return BadRequest("Could not update employee.");
            }

            return Ok("Updated employee of id: " + id);
        }

        // DELETE api/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == Guid.Empty.ToString())
            {
                return BadRequest("No parameter");
            }
            var successful = await _permissionService.DeletePermssionAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete employee with name: " + id);
            }

            return Ok("Deleted role " + id);
        }

    }
}