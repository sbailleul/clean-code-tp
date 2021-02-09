using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    class LibraryWriteRepository : ILibraryWriteRepository
    {
        public void Save(LibraryEntity library)
        {
            FileContext.Instance.Library = library;
            FileContext.Instance.Save();
        }
    }
}