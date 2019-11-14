using Scedulo.Server.Data.Entities.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        //public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public bool Newsleter { get; set; } = false;
        public double Balance { get; set; }
    }
}
