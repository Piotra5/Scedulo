using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.ServicePermission
{
    class AddServicePermssionViewModel
    {
        [Display(Name = "Employee")]
        public string EmployeeRoleId { get; set; }

        [Display(Name = "Service")]
        public string ServiceId { get; set; }
    }
}
