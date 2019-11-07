using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.RoomPermission
{
    public class RoomPermissionViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string ServiceRole { get; set; }

        [Display(Name = "Description")]
        public string Service { get; set; }
    }
}
