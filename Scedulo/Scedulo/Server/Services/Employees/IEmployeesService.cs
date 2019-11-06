using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Shared.Models.Employees;

namespace Scedulo.Server.Services.Employees
{
    public interface IEmployeesService
    {
        Task<EmployeesListViewModel> GetListOfAllEmployeesAsync();
        Task<EmployeeViewModel> GetEmployeeAsync(string Id);
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<Guid> GetEmployeeIdByUserIdAsync(string id);
        Task<bool> DeleteEmployeeAsync(string id);
        Task<bool> UpdateEmployeeAsync(string id, AddEmployeeViewModel changedEmployee);
    }
}