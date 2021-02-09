using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    public class BookWriteRepository : IBookWriteRepository
    {
        public  void Create(BookEntity book)
        {
            FileContext.Instance.Books.Add(book);
            FileContext.Instance.Save();
        }
    }
}