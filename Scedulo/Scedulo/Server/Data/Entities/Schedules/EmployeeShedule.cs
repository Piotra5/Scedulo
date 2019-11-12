using System;
using System.ComponentModel.DataAnnotations;
using Scedulo.Server.Data.Entities.Employees;

namespace Scedulo.Server.Data.Entities.Schedules
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