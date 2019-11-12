using Microsoft.AspNetCore.Identity;
using Scedulo.Server.Data.Entities.Base;
using Scedulo.Shared.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Server.Data.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DoB { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? HeightInCM { get; set; }
        public bool IsEmployed { get; set; } = false;
        public Address Address { get; set; }
        public string AddressId { get; set; }
    }
}
