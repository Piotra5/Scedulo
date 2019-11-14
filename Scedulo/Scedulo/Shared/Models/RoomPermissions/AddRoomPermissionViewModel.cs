using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.RoomPermissions
{
    public class AddRoomPermissionViewModel
    {
        [Display(Name = "Name")]
        public string ServiceRoleId { get; set; }

        [Display(Name = "Description")]
        public string RoomId { get; set; }
    }
}
