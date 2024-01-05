using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
                _appDbContext = appDbContext;
        }

        public async Task<Department?> GetDepartmen(int departmentId)
        {
            return await _appDbContext.Departments.FirstOrDefaultAsync(department => department.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartmens()
        {
            return await _appDbContext.Departments.ToListAsync();
        }
    }
}
