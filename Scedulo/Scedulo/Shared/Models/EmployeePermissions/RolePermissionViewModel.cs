using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.EmployeePermissions
{
    public class RolePermissionViewModel
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string RoleId { get; set; }
        public DateTime ExpiringDate { get; set; }
    }
}
