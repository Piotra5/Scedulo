using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Scedulo.Server.Data.Entities.ApplicationUsers;
using Scedulo.Server.Services.Reservations;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.Reservation;

namespace Scedulo.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private readonly IReservationsService _reservationsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(IReservationsService ReservationService, UserManager<ApplicationUser> UserManager)
        {
            _reservationsService = ReservationService;
            _userManager = UserManager;
        }

        // GET api/reservations
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservations = await _reservationsService.GetListOfAllReservationsAsync();
            return Ok(reservations);
        }

        //Post api/reservations
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody]AddReservationViewModel newReservation)
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
           
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            var feedback = await _reservationsService
            .AddServiceReservationAsync(newReservation, userId);

            if (feedback.Successful == false)
            {
                return BadRequest("Could not add service because: " + feedback.Message);
            }
            else
            {
                return Ok(feedback.Message);
            }
            return BadRequest("Could not add service because: " + feedback.Message);
        }
    }
}