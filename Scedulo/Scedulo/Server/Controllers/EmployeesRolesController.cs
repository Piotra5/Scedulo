using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Server.Services.Roles;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.EmployeeRoles;

namespace Scedulo.Server.Controllers
{
    [Authorize]
    [Route("api/employees/roles")]
    [ApiController]
    public class EmployeesRolesController : Controller
    {

        private readonly IRolesService _rolesService;
        //private readonly UserManager<ApplicationUser> _userManager;

        public EmployeesRolesController(IRolesService RolesService)
        {
            _rolesService = RolesService;
        }

        // GET api/employees/roles
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Employees = await _rolesService.GetListOfAllRolesAsync();
            return Ok(Employees);
        }

        // GET api/employees/roles/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _rolesService.GetRoleAsync(id);
            return Ok(employee);
        }

        // POST api/employees/roles
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]AddEmployeeRoleViewModel newRole)
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
            var role = new EmployeeRole
            {
                Name = newRole.Name,
                Description = newRole.Description
            };

            var successful = await _rolesService.AddRoleAsync(role);
            if (!successful)
            {
                return BadRequest("Could not add role.");
            }
            return Ok("Added role: " + role.Name);
        }

        //PUT api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpPut]
        public async Task<IActionResult> EditRole(string id, [FromBody]AddEmployeeRoleViewModel updatedRole)
        {
            var successful = await _rolesService
            .UpdateRoleAsync(id, updatedRole);

            if (!successful)
            {
                return BadRequest("Could not update employee.");
            }

            return Ok("Updated employee of id: " + id);
        }

        // DELETE api/employees/roles/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == Guid.Empty.ToString())
            {
                return BadRequest("No parameter");
            }
            var role = await _rolesService.GetRoleAsync(id);
            var successful = await _rolesService.DeleteRoleAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete employee with name: " + role.Name);
            }

            return Ok("Deleted role " + role.Name);
        }

    }
}