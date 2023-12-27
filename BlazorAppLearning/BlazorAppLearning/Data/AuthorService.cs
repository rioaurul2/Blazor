namespace BlazorAppLearning.Data
{
    public class AuthorService : IAuthorService
    {
        public DateTime CreationDate { get; set; }

        public List<Author> Authors = new();

        public AuthorService()
        {
            CreationDate = DateTime.Now;

            Authors = new List<Author>
            {
                new Author(1, "Jahson White", "0723167343", "Menlo Park", "JahsonWhite@yahoo.com", 8000),
                new Author(2, "Marjorie Green", "0767112343", "Okland", "MarjorieGreen@yahoo.com", 9000),
                new Author(3, "Cheryl Carson", "0723113643", "Barkeley", "CherylCarson@yahoo.com", 11000),
                new Author(4, "Michael O'Leary", "0723136443", "San Jose", "MichaelOLeary@yahoo.com", 9500),
                new Author(5, "Dean Straight", "0723118643", "Okland", "DeanStraight@yahoo.com", 12000)
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

        public void AddAuthor(Author? author)
        {
            if(author != null)
            {
                author.Id = Authors.Last().Id + 1;
                Authors.Add(author);
            }
        }

        public DateTime? GetCreateDate() { return CreationDate;}

        public string GetVersion() { return "v1"; }
    }
}
