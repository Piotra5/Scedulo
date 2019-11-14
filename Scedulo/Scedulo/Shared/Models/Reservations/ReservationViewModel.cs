using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scedulo.Shared.Models.Reservations
{
    public class ReservationViewModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }
        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }
        [Display(Name = "Service ID")]
        public string ServiceId { get; set; }
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }
        [Display(Name = "Reservation time")]
        public DateTimeOffset ReservationTime { get; set; }
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Service Time in Minutes")]
        public int ServiceTimeInMinutes { get; set; }
        [Display(Name = "Done: ")]
        public bool? Done { get; set; }
        [Display(Name = "Absence reason")]
        public String AbsenceReason { get; set; }
    }
}
