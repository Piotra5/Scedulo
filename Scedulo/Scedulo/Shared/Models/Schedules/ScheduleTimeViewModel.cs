using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.Schedules
{
    public class ScheduleTimeViewModel
    {
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }
    }
}
