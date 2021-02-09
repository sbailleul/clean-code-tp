using System;
using System.Threading.Tasks;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.UsesCases
{
    public class AddBookReference : INoReturnHandler<AddBookReference.AddBookCommand>, IAuthorizedAction
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;

        public record AddBookCommand
        {
            public AddBookCommand(string? userId, string title, string author)
            {
                UserId = userId;
                Title = title;
                Author = author;
            }

            public string? UserId { get; }
            public string Title { get; }
            public string Author { get; }
        }

        public bool IsAuthorized(string? username)
        {
            var library = _libraryReadRepository.Load().ToLibrary();
            return library.UserCanAddBook(new UserIdentifier(username));
        }

        public AddBookReference(ILibraryReadRepository libraryReadRepository, IBookWriteRepository bookWriteRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _bookWriteRepository = bookWriteRepository;
        }

        public  void Handle(AddBookCommand message)
        {
            var book = new Book(new BookTitle(message.Title), new BookAuthor(message.Author));
            var library = _libraryReadRepository.Load().ToLibrary();
            if (!library.CanAddBook(book)) throw new ApplicationException("Can't add new book");
             _bookWriteRepository.Create(book.ToBookEntity());
        }
    }
}