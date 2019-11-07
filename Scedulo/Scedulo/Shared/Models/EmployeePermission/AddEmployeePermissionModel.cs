using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.EmployeePermission
{
    public class AddEmployeePermissionModel
    {
        public string EmployeeId { get; set; }
        public string RoleId { get; set; }
        public DateTime ExpiringDate { get; set; }
    }
}
