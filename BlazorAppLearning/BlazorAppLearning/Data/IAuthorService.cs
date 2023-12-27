namespace BlazorAppLearning.Data
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();

        public Author? GetAuthorById(int authorId);

        public void AddAuthor(Author? author);

        public DateTime? GetCreateDate();

        public string GetVersion();
    }
}
