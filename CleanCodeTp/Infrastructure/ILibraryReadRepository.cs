using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface ILibraryReadRepository
    {
        LibraryEntity Load();
    }
}