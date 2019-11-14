using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.Schedules
{
    public class ScheduleViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }
        [Display(Name = "Start Time")]
        public DateTimeOffset StartTime { get; set; }
        [Display(Name = "Finish Time")]
        public DateTimeOffset EndTime { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        [Display(Name = "Present")]
        public bool Present { get; set; }
        [Display(Name = "Reason of absence")]
        public String AbsenceReason { get; set; }
    }
}
