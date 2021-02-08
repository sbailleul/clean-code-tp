using System.Collections.Generic;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Infrastructure
{
    class BookReadRepository : IBookReadRepository
    {
        public IList<BookEntity> GetAll() => FileContext.Instance.Books;
    }
}