using Scedulo.Server.Data.Entities.Services;
using Scedulo.Server.Data.Entities.Customers;
using Scedulo.Server.Data.Entities.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.ServiceReservations
{
    public class ServiceReservation
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public Service Service { get; set; }
        public string ServiceId { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public DateTime ReservationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ServiceTimeInMinutes { get; set; }
        public bool? Done { get; set; }
        [Column(TypeName = "text")]
        public String AbsenceReason { get; set; }
    }
}
