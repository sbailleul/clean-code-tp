using System;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Ui.OptionAction
{
    public class CreateUserAction : IOptionAction
    {
        public IPrinter Printer { get; }
        public IUserReadRepository UserReadRepository { get; }
        public IUserWriteRepository UserWriteRepository { get; }
        public ILibraryReadRepository LibraryReadRepository { get; }

        public CreateUserAction(IPrinter printer, IUserReadRepository userReadRepository,
            IUserWriteRepository userWriteRepository, ILibraryReadRepository libraryReadRepository)
        {
            Printer = printer;
            UserReadRepository = userReadRepository;
            UserWriteRepository = userWriteRepository;
            LibraryReadRepository = libraryReadRepository;
        }

        public string Run()
        {
            Printer.Print("Enter username");
            var username = Console.ReadLine();
            string? role;
            do
            {
                Printer.Print(
                    $"Enter your role <{nameof(Librarian)}> or <{nameof(Member)}> or <{nameof(Guest)}>");
                role = Console.ReadLine();
            } while (role != nameof(Librarian) && role != nameof(Member) && role != nameof(Guest));

            try
            {
                new CreateUser(LibraryReadRepository, UserWriteRepository).Handle(
                    new CreateUser.Command(username, role));
            }
            catch (ApplicationException e)
            {
                return e.Message;
            }

            UserWriteRepository.SetConnectedUserId(username);
            return $"Well done {username} !";
        }
    }
}