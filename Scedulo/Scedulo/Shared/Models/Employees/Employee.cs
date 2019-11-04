using System;
using System.ComponentModel.DataAnnotations;

namespace Scedulo.Shared.Models.Employees
{
    public class Employee
    {
        public Guid Id { get; set; }
        
        public virtual IdentityUser User { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Surname { get; set; }

        public string UserId { get; set; }

        public DateTimeOffset EmploymentDate { get; set; }

        public DateTimeOffset? ContractEndDate { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }

        public IdentityUser AdedBy { get; set; }

        public String AdedById { get; set; }
        public IdentityUser EditedBy { get; set; }

        public String EditedById { get; set; }

        public double BaseMonthSalary { get; set; }

    }
}