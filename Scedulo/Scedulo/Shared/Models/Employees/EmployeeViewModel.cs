using System;
using System.ComponentModel.DataAnnotations;

namespace Scedulo.Shared.Models.Employees
{
    public class EmployeeViewModel
    {
        [Display(Name = "Id")]
        public Guid Id{get; set;}

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Employment date")]
        public DateTimeOffset EmploymentDate { get; set; }

        [Display(Name = "End of the contract date")]
        public DateTimeOffset? ContractEndDate { get; set; }

        [Display(Name = "Created time")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Updated time")]
        public DateTimeOffset? UpdateDate { get; set; }

        [Display(Name = "AddedBy")]
        public string AdedBy { get; set; }

        [Display(Name = "Edited by")]
        public string EditedBy { get; set; }

        [Display(Name = "Base Month Salary")]
        public double BaseMonthSalary { get; set; }

    }
}