﻿using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
          var result = await _appDbContext.AddAsync(employee);

          await _appDbContext.SaveChangesAsync();

          return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result = await GetEmployee(employeeId);

            if (result is not null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee?> GetEmployee(int employeeId)
        {
          return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var result = await GetEmployee(employee.EmployeeId);

            if (result is not null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
