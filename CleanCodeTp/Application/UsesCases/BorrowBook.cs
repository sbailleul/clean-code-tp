using System.Threading.Tasks;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.UsesCases
{
    public class BorrowBook : IHandler<BorrowBook.Command, Task>, IAuthorizedAction
    {
        private ILibraryReadRepository _libraryReadRepository;
        private IUserReadRepository _userReadRepository;

        public BorrowBook(ILibraryReadRepository libraryReadRepository, IUserReadRepository userReadRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _userReadRepository = userReadRepository;
        }

        public class Command
        {
            public Command(string username, string bookTitle)
            {
                Username = username;
                BookTitle = bookTitle;
            }

            public string Username { get; }
            public string BookTitle { get; }
        }

        public Task Handle(Command command)
        {   
            var library = _libraryReadRepository.Load().ToLibrary();
            library.BorrowBook()
        }

        public bool IsAuthorized(string username)
        {
            var library = _libraryReadRepository.Load().ToLibrary();
            return library.UserCanBorrowBook(new UserIdentifier(username));
        }
    }
}