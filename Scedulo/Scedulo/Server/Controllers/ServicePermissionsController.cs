using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Services.ServicePermissions;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.ServicePermissions;

namespace Scedulo.Server.Controllers
{
    [Authorize]
    [Route("api/services/permissions")]
    [ApiController]
    public class ServicePermissionsController : Controller
    {

        private readonly IServicesPermissionService _servicesPermissionService;

        public ServicePermissionsController(IServicesPermissionService ServicesPermissionService)
        {
            _servicesPermissionService = ServicesPermissionService;
        }

        // GET api/services/permissions
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Employees = await _servicesPermissionService.GetListOfAllServicesPermissionsAsync();
            return Ok(Employees);
        }

        // GET api/services/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _servicesPermissionService.GetServicePermissionByIdAsync(id);
            return Ok(employee);
        }

        //POST api/services/permissions
        [HttpPost]
        public async Task<IActionResult> AddPermmission([FromBody]AddServicePermissionViewModel newPermission)
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

            var successful = await _servicesPermissionService.AddServicePermissionAsync(newPermission);
            if (successful == null)
            {
                return BadRequest("Could not add service permission.");
            }
            return Ok("Added serivce permission of ID: " + successful);
        }

        //PUT api/services/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpPut]
        public async Task<IActionResult> EditPermission(string id, [FromBody]ServicePermissionViewModel updatedPermission)
        {
            var successful = await _servicesPermissionService
            .UpdateServicePermissionAsync(id, updatedPermission);

            if (!successful)
            {
                return BadRequest("Could not update serivce permission.");
            }

            return Ok("Updated serivce permissione of id: " + id);
        }

        // DELETE api/services/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == Guid.Empty.ToString())
            {
                return BadRequest("No parameter");
            }
            var successful = await _servicesPermissionService.DeleteServicePermissionAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete serivce permission with name: " + id);
            }

            return Ok("Deleted serivce permission " + id);
        }
    }
}