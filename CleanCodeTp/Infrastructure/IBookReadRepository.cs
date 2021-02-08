using System.Collections.Generic;
using System.IO;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface IBookReadRepository
    {
        IList<BookEntity> GetAll();
    }
}