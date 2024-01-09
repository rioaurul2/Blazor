﻿using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DataBidingDemoBase : ComponentBase
    {
        protected string Name { get; set; } = "Tom";
        protected string Gender { get; set; } = "Male";
        public string Description { get; set; } = "";
    }
}
