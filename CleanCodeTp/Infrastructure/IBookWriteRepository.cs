using System.Collections;
using System.IO;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface IBookWriteRepository
    {
        Task Create(BookEntity book);   
    }
}

