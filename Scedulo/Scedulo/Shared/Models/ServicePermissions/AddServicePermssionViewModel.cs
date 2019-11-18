using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.ServicePermissions
{
    public class AddServicePermissionViewModel
    {
        [Display(Name = "Employee")]
        public string RolePermissionId { get; set; }

        [Display(Name = "Service")]
        public string ServiceId { get; set; }
    }
}
