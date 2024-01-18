using AutoMapper;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IMapper EmployeeMapper { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; } = new();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new();
        public List<Department> Departments { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if(employeeId != 0)
            {
                Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
            }
            else
            {
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now,
                    PhotoPath = "images/john.png",
                    Department = new Department
                    {
                        DepartmentName = "IT"
                    }
                };
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();

            EmployeeMapper.Map(Employee, EditEmployeeModel);

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department = Employee.Department;
        }

        protected async Task HandleValidSubmit()
        {
            EmployeeMapper.Map(EditEmployeeModel, Employee);

            HttpResponseMessage result = null;

            if(Employee.EmployeeId != 0) {

                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }

            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
