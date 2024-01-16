using EmployeeManagementModels;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<Department[]>("api/department");
        }

        public async Task<Department> GetDepartmentsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"api/department/{id}");
        }
    }
}
