using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagementModels.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowDomain { get; set; }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) {
                string[] strings = value.ToString().Split("@");
                if (strings.Length > 1 && strings[1].ToUpper() == AllowDomain.ToUpper())
                {
                    return null;
                }
                return new ValidationResult($"Domain must be {AllowDomain}", new[] { validationContext.MemberName });
            }

            return null;
        }
    }
}
