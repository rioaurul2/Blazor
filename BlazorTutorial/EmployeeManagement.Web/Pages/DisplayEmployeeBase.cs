using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Inject]
        private IEmployeeService EmployeeService { get; set; }
        [Inject] 
        NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> OnDeleteEmployee { get; set; }

        protected Custom.Components.ConfirmBase DeleteConfirmation { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs args)
        {
            await OnEmployeeSelection.InvokeAsync((bool)args.Value);
        }

        protected void DeleteEmployee()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool DeleteConfirmed)
        {
            if (DeleteConfirmed)
            {
                var result = await EmployeeService.DeleteEmployee(Employee.EmployeeId);

                //this is force reloading and there exist a better method than this
                //NavigationManager.NavigateTo("/", true);

                await OnDeleteEmployee.InvokeAsync(Employee.EmployeeId);

            }
        }
    }
}
