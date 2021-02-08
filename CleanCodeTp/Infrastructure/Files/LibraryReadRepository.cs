using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    public class LibraryReadRepository : ILibraryReadRepository
    {
        public LibraryEntity Load() => FileContext.Instance.Library;
    }
}