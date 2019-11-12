using Scedulo.Server.Data.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Services
{
    public class RoleServicePermssion
    {
        public Guid Id { get; set; }
        public EmployeeRole ServiceRole { get; set; }
        public string ServiceRoleId { get; set; }
        public Service Service { get; set; }
        public string ServiceId { get; set; }
    }
}

