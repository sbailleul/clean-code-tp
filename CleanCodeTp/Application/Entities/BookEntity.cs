namespace CleanCodeTp.Application.Entities
{
    public class BookEntity
    {
        public BookEntity(string author, string title)
        {
            Author = author;
            Title = title;
        }

        public string Author { get; set; }
        public string Title { get; set; }
    }
}