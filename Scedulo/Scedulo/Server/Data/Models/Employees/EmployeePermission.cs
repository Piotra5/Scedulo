using System;
using System.ComponentModel.DataAnnotations;

namespace Scedulo.Server.Data.Models.Employees
{
    public class EmployeePermission
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        public EmployeeRole Role {get; set;}
        public DateTime ExpiringDate { get; set; }

    }
}