using Microsoft.AspNetCore.Mvc;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext Context)
        {
            _context = Context;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            var saveResult = await _context.SaveChangesAsync();
            return Ok("Added service: " + newCustomer.Id.ToString());
        }
    }
}
