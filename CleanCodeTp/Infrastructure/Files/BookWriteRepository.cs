using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Infrastructure
{
    public class BookWriteRepository : IBookWriteRepository
    {
        public async Task Create(BookEntity book)
        {
            FileContext.Instance.Books.Add(book);
            await FileContext.Instance.Save();
        }
    }
}