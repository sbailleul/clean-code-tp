using System;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Ui.OptionAction
{
    public class ReturnBookAction : IOptionAction
    {
        private readonly IPrinter _printer;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ILibraryReadRepository _libraryReadRepository;

        public ReturnBookAction(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository,
            ILibraryReadRepository libraryReadRepository, IPrinter printer)
        {
            _printer = printer;
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _libraryReadRepository = libraryReadRepository;
        }

        public string Run()
        {
            _printer.Print("Enter the book title");
            var bookTitle = Console.ReadLine() ?? string.Empty;

            var connectedUser = _userReadRepository.GetConnectedUserId() ?? string.Empty;
            var borrowBook = new ReturnBook(_libraryReadRepository, _userWriteRepository);
            borrowBook.IsAuthorized(connectedUser);
            if (!borrowBook.IsAuthorized(connectedUser))
            {
                return "You can't return book !";
            }

            try
            {
                borrowBook.Handle(new ReturnBook.Command(connectedUser, bookTitle));
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return $"Book {bookTitle} returned!";
        }
    }
}