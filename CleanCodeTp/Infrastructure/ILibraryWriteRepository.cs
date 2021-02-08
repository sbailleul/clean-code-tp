using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface ILibraryWriteRepository
    {
        Task Save(LibraryEntity library);
    }
}