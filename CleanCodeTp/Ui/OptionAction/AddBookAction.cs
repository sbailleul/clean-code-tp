using System;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Ui.OptionAction
{
    public class AddBookAction : IOptionAction
    {
        private readonly IPrinter _printer;
        private readonly IUserReadRepository _userReadRepository;
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;

        public AddBookAction(IUserReadRepository userReadRepository,
            ILibraryReadRepository libraryReadRepository, IPrinter printer,
            IBookWriteRepository bookWriteRepository)
        {
            _printer = printer;
            _bookWriteRepository = bookWriteRepository;
            _userReadRepository = userReadRepository;
            _libraryReadRepository = libraryReadRepository;
        }

        public string Run()
        {
            _printer.Print("Enter the book title");
            var bookTitle = Console.ReadLine();

            _printer.Print("Enter the book title");
            var bookAuthor = Console.ReadLine();

            var addBook = new AddBookReference(_libraryReadRepository, _bookWriteRepository);
            var connectedUser = _userReadRepository.GetConnectedUserId();
            if (!addBook.IsAuthorized(connectedUser))
            {
                return "You can't add book reference !";
            }

            try
            {
                addBook.Handle(new AddBookReference.AddBookCommand(connectedUser, bookTitle ?? string.Empty,
                    bookAuthor ?? string.Empty));
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return $"Book {bookTitle} added!";
        }
    }
}