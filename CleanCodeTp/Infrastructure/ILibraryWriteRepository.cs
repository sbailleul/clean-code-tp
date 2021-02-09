using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface ILibraryWriteRepository
    {
        void Save(LibraryEntity library);
    }
}