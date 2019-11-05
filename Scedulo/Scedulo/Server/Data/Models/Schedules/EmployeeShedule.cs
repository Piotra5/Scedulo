using System;
using System.ComponentModel.DataAnnotations;
using Scedulo.Server.Data.Models.Employees;

namespace Scedulo.Server.Data.Models.Schedules
{
    public class EmployeeSchedule
    {

        public Guid Id { get; set; }       
        public Employee Employee {get; set;}
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset FinishTime { get; set; }
        public String Role { get; set; }
        public bool Present { get; set; } = false;
        public String AbsenceReason {get; set;}

    }
}