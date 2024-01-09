using EmployeeManagementModels;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int id);
    }
}
