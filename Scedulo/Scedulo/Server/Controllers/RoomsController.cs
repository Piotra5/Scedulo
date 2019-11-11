using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Services.Rooms;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.Rooms;

namespace Scedulo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : Controller
    {
        private readonly IRoomsService _roomsService;

        public RoomsController(IRoomsService RoomsService)
        {
            _roomsService = RoomsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET api/services
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rooms = await _roomsService.GetListOfAllRoomsAsync();
            return Ok(rooms);
        }

        // GET api/services/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var room = await _roomsService.GetRoomAsync(id);
            return Ok(room);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody]AddRoomViewModel newRoom)
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

            var successful = await _roomsService
            .AddRoomAsync(newRoom);

            if (!successful)
            {
                return BadRequest("Could not add service.");
            }

            return Ok("Added service: " + newRoom.Name.ToUpper());
        }

        // PUT api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditService(string id, RoomViewModel service)
        {
            var successful = await _roomsService
            .UpdateRoomAsync(id, service);

            if (!successful)
            {
                return BadRequest("Could not update employee.");
            }

            return Ok("Updated employee of id: " + id);
        }

        // DELETE api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteService(string id)
        {
            if (id == "")
            {
                return BadRequest("Could not delete with empty id.");
            }
            var room = await _roomsService.GetRoomAsync(id);
            var successful = await _roomsService.DeleteRoomAsync(id);

            if (!successful)
            {
                return BadRequest("Could not delete service.");
            }

            return Ok("Deleted service " + room.Name);
        }
    }
}