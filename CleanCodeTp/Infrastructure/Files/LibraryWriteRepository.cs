using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    class LibraryWriteRepository : ILibraryWriteRepository
    {
        public async Task Save(LibraryEntity library)
        {
            FileContext.Instance.Library = library;
            await FileContext.Instance.Save();
        }
    }
}