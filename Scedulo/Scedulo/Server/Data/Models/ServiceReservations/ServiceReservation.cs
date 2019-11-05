using Scedulo.Server.Data.Models.Customers;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Server.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Models.ServiceReservations
{
    public class ServiceReservation
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Employee Employee { get; set; }  
        public DateTimeOffset ReservationTime { get; set; }
        public DateTimeOffset EstimatedTime { get; set; }
        public bool? Done { get; set; }
        [Column(TypeName = "text")]
        public String AbsenceReason { get; set; }
    }
}
