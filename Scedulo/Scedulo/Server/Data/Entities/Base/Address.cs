using Scedulo.Server.Data.Entities.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Base
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
