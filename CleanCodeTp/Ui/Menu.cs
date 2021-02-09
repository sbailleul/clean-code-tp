using System;
using System.Collections.Generic;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;
using CleanCodeTp.Ui.OptionAction;

namespace CleanCodeTp.Ui
{
    public class Menu
    {
        private static IUserReadRepository _userReadRepository = new UserReadRepository();
        private static IUserWriteRepository _userWriteRepository = new UserWriteRepository();
        private static ILibraryReadRepository _libraryReadRepository = new LibraryReadRepository();
        private static IBookReadRepository _bookReadRepository = new BookReadRepository();
        private static IBookWriteRepository _bookWriteRepository = new BookWriteRepository();

        public static void Run(IPrinter printer)
        {
            printer.Print("WELCOME IN LIBRARY MANAGEMENT PROGRAM");
            // printer.Print("Please enter your username : ");
            var username = String.Empty;
            var rootOption = new Option(null, printer, String.Empty);


            rootOption.Options = new List<Option>
            {
                new Option(rootOption, printer, "Log with your username",
                    new ConnectUserAction(printer, _userReadRepository, _userWriteRepository)),
                new Option(rootOption, printer, "Create an account",
                    new CreateUserAction(printer, _userReadRepository, _userWriteRepository, _libraryReadRepository)),
                new(rootOption, printer, "List books",
                    new ListAllBooksActions(_libraryReadRepository, _bookReadRepository, _userReadRepository)),
                new(rootOption, printer, "Add a book",
                    new AddBookAction(_userReadRepository, _libraryReadRepository, printer, _bookWriteRepository)),
                new(rootOption, printer, "Borrow a book",
                    new BorrowBookAction(_userReadRepository, _userWriteRepository, _libraryReadRepository, printer)),
                new(rootOption, printer, "Return a book",
                    new ReturnBookAction(_userReadRepository, _userWriteRepository, _libraryReadRepository, printer)),
            };

            rootOption.Run();
            printer.Print("GOOD BYE!");
        }
    }
}