using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.EmployeePermission
{
    public class EmployeePermissionsListModel
    {
        public List<EmployeePermissionViewModel> Permissions { get; set; } = new List<EmployeePermissionViewModel>();
    }
}
