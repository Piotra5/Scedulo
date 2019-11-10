using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.ServicePermission
{
    public class AddServicePermissionViewModel
    {
        [Display(Name = "Employee")]
        public string ServiceRoleId { get; set; }

        [Display(Name = "Service")]
        public string ServiceId { get; set; }
    }
}
