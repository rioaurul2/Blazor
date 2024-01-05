using EmployeeManagementModels;

namespace EmployeeManagement.Api.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmens();
        Task<Department?> GetDepartmen(int deparmentId);
    }
}
