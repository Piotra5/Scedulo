using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Data.Entities.Employees;
using Scedulo.Server.Data.Entities.Schedules;
using Scedulo.Server.Services.Schedules;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.Schedules;

namespace Scedulo.Server.Controllers
{
    [Authorize]
    [Route("api/schedules")]
    [ApiController]
    public class SchedulesController : Controller
    {
        private readonly ISchedulesService _schedulesService;

        public SchedulesController(ISchedulesService SchedulesService)
        {
            _schedulesService = SchedulesService;
        }

        // GET api/schedules/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Schedules = await _schedulesService.GetScheduleList();
            return Ok(Schedules);
        }

        // GET api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318/schedules
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Schedules = await _schedulesService.GetScheduleListForEmployeeAsync(id);
            return Ok(Schedules);
        }

        // GET api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318/schedules/
        [Route("/api/employees/{employeeID}/schedules/{startTime}")]
        [HttpGet]
        public async Task<IActionResult> GetFromDateForEmployee(string employeeID, DateTime startTime)
        {
            var Schedules = await _schedulesService.GetScheduleListFromDateAsync(employeeID, startTime);
            return Ok(Schedules);
        }

        // GET api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318/schedules/
        [Route("/api/schedules/{startTime}")]
        [HttpGet]
        public async Task<IActionResult> GetFromDateAll(DateTime startTime)
        {
            var Schedules = await _schedulesService.GetFromDateAll(startTime);
            return Ok(Schedules);
        }

        // POST api/schedules/
        [HttpPost]
        public async Task<IActionResult> AddSchedule([FromBody]AddScheduleViewModel newSchedule)
        {
            if(newSchedule.EndTime< newSchedule.StartTime)
            {
                return BadRequest("Start date time has to be smaller than end time");
            }
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
            //var schedule = new EmployeeSchedule
            //{
            //    Id = new Guid(),
            //    EmployeeId = newSchedule.EmployeeId,
            //    StartTime = newSchedule.StartTime,
            //    EndTime = newSchedule.EndTime,
            //    Role = newSchedule.Role,
            //    Present = false,
            //    AbsenceReason = ""
            //};
            var successful = await _schedulesService.AddScheduleAsync(newSchedule);
            if (!successful)
            {
                return BadRequest("Could not add schedule.");
            }
            return Ok("Added schedule for : " + newSchedule.EmployeeId + " for: " + newSchedule.StartTime + " - " + newSchedule.EndTime);
        }
    }
}