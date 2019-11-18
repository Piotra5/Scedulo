using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.EmployeePermissions
{
    public class RolePermissionsListModel
    {
        public List<RolePermissionViewModel> Permissions { get; set; } = new List<RolePermissionViewModel>();
    }
}
