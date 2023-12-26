namespace BlazorAppLearning.Data
{
    public class Author
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? City { get; set; }

        public Author(int id, string fullName, string phone, string city)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            City = city;
        }
    }
}
