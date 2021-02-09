using System;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Ui.OptionAction
{
    public class BorrowBookAction : IOptionAction
    {
        private readonly IPrinter _printer;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ILibraryReadRepository _libraryReadRepository;

        public BorrowBookAction(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository,
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
            var borrowBook = new BorrowBook(_libraryReadRepository, _userWriteRepository);
            borrowBook.IsAuthorized(connectedUser);
            if (!borrowBook.IsAuthorized(connectedUser))
            {
                return "You can't borrow book !";
            }

            try
            {
                borrowBook.Handle(new BorrowBook.Command(connectedUser, bookTitle));
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return $"Book {bookTitle} borrowed!";
        }
    }
}