using System.Collections;
using System.IO;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface IBookWriteRepository
    {
        void Create(BookEntity book);   
    }
}

