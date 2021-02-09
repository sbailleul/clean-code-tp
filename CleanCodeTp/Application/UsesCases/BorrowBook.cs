using System;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.UsesCases
{
    public class BorrowBook : INoReturnHandler<BorrowBook.Command>, IAuthorizedAction
    {
        private ILibraryReadRepository _libraryReadRepository;
        private IUserWriteRepository _userWriteRepository;

        public BorrowBook(
            ILibraryReadRepository libraryReadRepository, IUserWriteRepository userWriteRepository
        )
        {
            _libraryReadRepository = libraryReadRepository;
            _userWriteRepository = userWriteRepository;
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

        public void Handle(Command message)
        {
            var library = _libraryReadRepository.Load().ToLibrary();
            var borrowedBook = library.BorrowBook(new UserIdentifier(message.Username), new BookTitle(message.BookTitle));
            if (borrowedBook is null) throw new AggregateException("Book doesn't exists");
            _userWriteRepository.AddBorrowedBookToUser(message.Username,
                borrowedBook.ToBorrowedBookEntity(message.Username)
                );
        }

        public bool IsAuthorized(string? username)
        {
            var library = _libraryReadRepository.Load().ToLibrary();
            return library.UserCanBorrowBook(new UserIdentifier(username));
        }
    }
}