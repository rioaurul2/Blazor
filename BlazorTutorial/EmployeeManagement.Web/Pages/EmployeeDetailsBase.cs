using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        private IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Employee Employee { get; set; } = new();

        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";
        }

        protected void HideFooter()
        {
            if (string.IsNullOrEmpty(CssClass))
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = "";
            }

        }
    }
}
