using EmployeeManagementModels;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
