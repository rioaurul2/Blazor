using EmployeeManagementModels;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetDepartments();
        public Task<Department> GetDepartmentsById(int id);
    }
}
