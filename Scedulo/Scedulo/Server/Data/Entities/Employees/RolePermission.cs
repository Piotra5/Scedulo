using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Employees
{
    public class RolePermission
    {
        public Guid Id { get; set; }
        public DateTime ExpiringTime { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public string EmplyoeeRoleId { get; set; }
    }
}
