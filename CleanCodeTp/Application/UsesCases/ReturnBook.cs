using System.Threading.Tasks;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.UsesCases
{
    public class ReturnBook : INoReturnHandler<ReturnBook.Command>, IAuthorizedAction
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

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


        public ReturnBook(ILibraryReadRepository libraryReadRepository, IUserWriteRepository userWriteRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public bool IsAuthorized(string? username)
        {
            var library = _libraryReadRepository.Load().ToLibrary();
            return library.UserCanReturnBook(new UserIdentifier(username));
        }

        public void Handle(Command message)
        {
            var library = _libraryReadRepository.Load().ToLibrary();
            if (!library.ReturnBook(new UserIdentifier(message.Username), new BookTitle(message.BookTitle)))
                throw new ApplicationException("Can't return book damn!");
            _userWriteRepository.RemoveBorrowedBookToUser(message.Username, message.BookTitle);
        }
    }
}