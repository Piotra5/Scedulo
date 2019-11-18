using Scedulo.Server.Data.Entities.ApplicationUsers;
using Scedulo.Server.Data.Entities.Schedules;
using Scedulo.Server.Data.Entities.ServiceReservations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scedulo.Server.Data.Entities.Employees
{
    public class Employee
    {
        public Guid Id { get; set; } 
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }
        public DateTimeOffset? ContractEndDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public string AddedById { get; set; }
        public ApplicationUser EditedBy { get; set; }
        public string EditedById { get; set; }
        public double BaseMonthSalary { get; set; }

        public virtual ICollection<EmployeeRole> RolePermissions { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual ICollection<ServiceReservation> ServiceReservations { get; set; }
    }
}