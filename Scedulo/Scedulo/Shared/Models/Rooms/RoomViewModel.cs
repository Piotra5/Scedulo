using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.Rooms
{
    public class RoomViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Display(Name = "Name ")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
