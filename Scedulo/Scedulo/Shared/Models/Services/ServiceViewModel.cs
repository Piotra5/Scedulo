using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Shared.Models.Services
{
    public class ServiceViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Time required")]
        public int TimeRequiredInMinutes { get; set; }
        [Display(Name = "Required role")]
        public bool RoleReqired {get; set;}
        [Display(Name = "Price")]
        public double PriceInPln {get; set;}
        
    }
}