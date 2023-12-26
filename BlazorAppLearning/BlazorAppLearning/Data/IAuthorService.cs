namespace BlazorAppLearning.Data
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();

        public Author? GetAuthorById(int authorId);

        public DateTime? GetCreateDate();

        public string GetVersion();
    }
}
