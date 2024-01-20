using EmployeeManagementModels;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee employee)
        {
            return await _httpClient.PutAsJsonAsync("api/Employees/", employee);
        }

        public async Task<HttpResponseMessage> CreateEmployee(Employee employee)
        {
            return await _httpClient.PostAsJsonAsync("api/Employees/", employee);
        }

        public async Task<HttpResponseMessage> DeleteEmployee(int id)
        {
           var result = await _httpClient.DeleteAsync($"api/Employees/{id}");

           return result;
        }
    }
}
