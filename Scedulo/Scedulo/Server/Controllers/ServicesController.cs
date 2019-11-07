using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Shared.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Services.Services;
using Scedulo.Shared.Models.Base;

namespace CalendaroNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService ServicesService)
        {
            _servicesService = ServicesService;
        }

        // GET api/services
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _servicesService.GetListOfAllServicesAsync();
            return Ok(services);
        }
        
        // GET api/services/714921f1-8e4d-4d8f-a28c-3544f92e318
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _servicesService.GetServiceAsync(id);
            return Ok(employee);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody]ServiceViewModel newService)
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

            var successful = await _servicesService
            .AddServiceAsync(newService);

            if (!successful)
            {
                return BadRequest("Could not add service.");
            }

            return Ok("Added service: " + newService.Name.ToUpper() );
        }

        // PUT api/employees/714921f1-8e4d-4d8f-a28c-3544f92e318
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditService(string id, ServiceViewModel service)
        {
            var successful = await _servicesService
            .UpdateServiceAsync(id, service);

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
            var service = await _servicesService.GetServiceAsync(id);
            var successful = await _servicesService.DeleteServiceAsync(id);
            
            if (!successful)
            {
                return BadRequest("Could not delete service.");
            }

            return Ok("Deleted service " + service.Name);
        }
    }
}