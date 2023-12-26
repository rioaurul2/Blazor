namespace BlazorAppLearning.Data
{
    public class AuthorService : IAuthorService
    {
        public DateTime CreationDate { get; set; }

        public List<Author> Authors { get; set; }

        public AuthorService()
        {
            CreationDate = DateTime.Now;

            Authors = new List<Author>
            {
                new Author(1, "Jahson White", "0723167343", "Menlo Park"),
                new Author(2, "Marjorie Green", "0767112343", "Okland"),
                new Author(3, "Cheryl Carson", "0723113643", "Barkeley"),
                new Author(4, "Michael O'Leary", "0723136443", "San Jose"),
                new Author(5, "Dean Straight", "0723118643", "Okland")
            };
        }

        public List<Author> GetAuthors()
        {
            return Authors;
        }

        public Author? GetAuthorById(int id)
        {
            var author = Authors.FirstOrDefault(person => person.Id == id);

            return author;
        }

        public DateTime? GetCreateDate() { return CreationDate;}

        public string GetVersion() { return "v1"; }
    }
}
