using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.Reservations
{
    public class ReservationSechdule
    {
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }
        [Display(Name = "Start Time")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Estimated Time")]
        public int ServiceTimeInMinutes{ get; set; }
    }
}
