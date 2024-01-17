﻿using EmployeeManagementModels.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required (ErrorMessage ="First name cannot be empty")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowDomain="domain.ro")]
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
