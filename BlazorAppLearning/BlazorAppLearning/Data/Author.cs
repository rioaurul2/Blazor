using System.ComponentModel.DataAnnotations;

namespace BlazorAppLearning.Data
{
    public class Author
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="This is required")]
        public string? FullName { get; set; }

        public string? Phone { get; set; }
        [Required]
        [StringLength (20,ErrorMessage ="City name can not be longer than 20 chars")]
        public string? City { get; set; }
        [Required]
        [DataType (DataType.EmailAddress)]
        [EmailAddress (ErrorMessage = "Please enter valid email addres")]
        public string? Email { get; set; }
        [Required]
        [Range(100,9999999,ErrorMessage ="Salary should be greater than $1000")]
        public int? Salary { get; set; }

        public Author()
        {
            
        }

        public Author(int id, string fullName, string phone, string city, string? email, int? salary)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            City = city;
            Email = email;
            Salary = salary;
        }
    }
}
