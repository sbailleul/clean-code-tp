using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Application.UsesCases
{
    public class CreateLibrarian:IHandler<CreateLibrarian.CreateLibrarianCommand, Task>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public record CreateLibrarianCommand
        {
            public CreateLibrarianCommand(string username)
            {
                Username = username;
            }

            public string Username { get; }
        }

        public CreateLibrarian(ILibraryReadRepository libraryReadRepository, IUserWriteRepository userWriteRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task Handle(CreateLibrarianCommand command)
        {
            var user = new Librarian(new UserIdentifier(command.Username));
            var library = _libraryReadRepository.Load().ToLibrary();
            if(!library.CanSetLibrarian(user)) return;
            
            library.SetLibrarian(user);
            await _userWriteRepository.Create(user.ToUserEntity());
        }
    }
}