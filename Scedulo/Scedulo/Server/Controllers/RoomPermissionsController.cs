using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Services.RoomPermissions;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.RoomPermissions;

namespace Scedulo.Server.Controllers
{
 //   [Authorize]
    [Route("api/rooms/permissions")]
    [ApiController]
    public class RoomPermissionsController : Controller
    {

        private readonly IRoomPermissionsService _roomPermissionsService;

        public RoomPermissionsController(IRoomPermissionsService RoomPermissionsService)
        {
            _roomPermissionsService = RoomPermissionsService;
        }

        // GET api/rooms/permissions
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissions = await _roomPermissionsService.GetListOfAllPermissionsAsync();
            return Ok(permissions);
        }

        // GET api/rooms/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _roomPermissionsService.GetPermissionByIdAsync(id);
            return Ok(employee);
        }

        // GET /api/roles/714921f1-8e4d-4d8f-a28c-3544f92e318/rooms/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [Route("/api/roles/{roleId}/room/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetByRole(string roleId)
        {
            var employee = await _roomPermissionsService.GetPermissionsByRoleIdAsync(roleId);
            return Ok(employee);
        }

        // GET /api/roles/714921f1-8e4d-4d8f-a28c-3544f92e318/rooms/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [Route("/api/rooms/{roomId}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetByRoom(string roomId)
        {
            var employee = await _roomPermissionsService.GetPermissionsByRoomIdAsync(roomId);
            return Ok(employee);
        }

        //POST api/rooms/permissions
        [HttpPost]
        public async Task<IActionResult> AddPermmission([FromBody]AddRoomPermissionViewModel newPermission)
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

            var successful = await _roomPermissionsService.AddPermissionAsync(newPermission);
            if (successful == null)
            {
                return BadRequest("Could not add room permission.");
            }
            return Ok("Added room permission of ID: " + successful);
        }

        //PUT api/rooms/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpPut]
        public async Task<IActionResult> EditPermission(string id, [FromBody]RoomPermissionViewModel updatedPermission)
        {
            var successful = await _roomPermissionsService
            .UpdatePermissionAsync(id, updatedPermission);

            if (!successful)
            {
                return BadRequest("Could not update serivce permission.");
            }

            return Ok("Updated serivce permissione of id: " + id);
        }

        // DELETE api/rooms/permissions/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == Guid.Empty.ToString())
            {
                return BadRequest("No parameter");
            }
            var successful = await _roomPermissionsService.DeletePermissionAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete serivce permission with name: " + id);
            }

            return Ok("Deleted serivce permission " + id);
        }
    }
}