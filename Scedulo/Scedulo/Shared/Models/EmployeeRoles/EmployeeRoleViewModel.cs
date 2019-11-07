using Scedulo.Shared.Models.RoomPermission;
using Scedulo.Shared.Models.ServicePermission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.EmployeeRoles
{
    public class EmployeeRoleViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Available Services")]
        public List<ServicePermissionViewModel> AvailableServices { get; set; } = new List<ServicePermissionViewModel>();

        [Display(Name = "Available Rooms")]
        public List<RoomPermissionViewModel> AvailableRooms { get; set; } = new List<RoomPermissionViewModel>();
    }
}

