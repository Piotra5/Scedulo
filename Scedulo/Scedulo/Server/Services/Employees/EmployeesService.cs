using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Models.ApplicationUsers;
using Scedulo.Shared.Models.Employees;

namespace Scedulo.Server.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        #region EmployeeService()
        public EmployeesService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #endregion

        #region GetEmployeeById()
        public async Task<EmployeeViewModel> GetEmployeeAsync(string id)
        {
            var employee = await _context.Employees
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();
            var user = (await _userManager.FindByIdAsync(employee.User.Id));
            var addedBy = (await _userManager.FindByIdAsync(employee.AddedBy.Id));
            var editedBy = (await _userManager.FindByIdAsync(employee.EditedBy.Id));

            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id.ToString(),
                FirstName = user.Name,
                Surname = user.Surname,
                EmploymentDate = employee.EmploymentDate,
                ContractEndDate = employee.ContractEndDate,
                CreatedDate = employee.CreatedDate,
                UpdateDate = employee.UpdateDate,
                AdedBy = addedBy.Name + addedBy.Surname + " e-mail:" + addedBy.Email,
                EditedBy = editedBy.Name + editedBy.Surname + " e-mail:" + editedBy.Email,
                BaseMonthSalary = employee.BaseMonthSalary
            };

            return employeeViewModel;

        }
        #endregion

        #region GetEmployeeById()
        public async Task<Guid> GetEmployeeIdByUserIdAsync(string id)
        {
            var employee = await _context.Employees
                //.Where(x => x. == id)
                .SingleOrDefaultAsync();

            return employee.Id;

        }
        #endregion

        #region AddEmployeeService()
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteEmployeeService()
        public async Task<bool> DeleteEmployeeAsync(string id)
        {
            var deleted = false;
            var employee = await _context.Employees
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (employee != null)
            {
                _context.Remove(employee);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
        #endregion

        #region UpdateEmployeeAsync()
        public async Task<bool> UpdateEmployeeAsync(string id, AddEmployeeViewModel changedEmployee)
        {
            var employee = await _context.Employees
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            var user = await _userManager.FindByIdAsync(changedEmployee.UserId);
            var editedBy = await _userManager.FindByIdAsync(changedEmployee.EditedBy);

            if (employee != null)
            {
                employee.User = user;
                employee.EmploymentDate = changedEmployee.EmploymentDate;
                employee.ContractEndDate = changedEmployee.ContractEndDate;
                employee.BaseMonthSalary = changedEmployee.BaseMonthSalary;
                employee.UpdateDate = changedEmployee.UpdateDate;
                employee.EditedBy = editedBy;
                _context.Update(employee);

            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region GetListOfAllEmployeesAsync()
        public async Task<EmployeesListViewModel> GetListOfAllEmployeesAsync()
        {
            var employeesList = await _context.Employees
                .ToListAsync();
            var employeesViewList = new EmployeesListViewModel();
            foreach (var employee in employeesList)
            {
                var user = (await _userManager.FindByIdAsync(employee.UserId));
                var addedBy = (await _userManager.FindByIdAsync(employee.AddedById));
                var editedBy = (await _userManager.FindByIdAsync(employee.EditedById));
                var employeeView = new EmployeeViewModel
                {
                    Id = employee.Id.ToString(),
                    FirstName = user.Name,
                    Surname = user.Surname,
                    EmploymentDate = employee.EmploymentDate,
                    ContractEndDate = employee.ContractEndDate,
                    CreatedDate = employee.CreatedDate,
                    UpdateDate = employee.UpdateDate,
                    AdedBy = editedBy == null ? addedBy.Name + addedBy.Surname + " e-mail:" + addedBy.Email : null;,
                    EditedBy = editedBy == null ? editedBy.Name + editedBy.Surname + " e-mail:" + editedBy.Email : null,
                    BaseMonthSalary = employee.BaseMonthSalary
                };
                employeesViewList.CompanyEmployees.Add(employeeView);
            }

            return employeesViewList;
        }
        #endregion
    }
}