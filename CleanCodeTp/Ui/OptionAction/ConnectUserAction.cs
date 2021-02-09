using System;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Ui.OptionAction
{
    public class ConnectUserAction: IOptionAction
    {
        
        public IPrinter Printer { get; }
        public IUserReadRepository UserReadRepository { get; }
        public IUserWriteRepository UserWriteRepository { get; }
        public ConnectUserAction(IPrinter printer, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            Printer = printer;
            UserReadRepository = userReadRepository;
            UserWriteRepository = userWriteRepository;
        }

        public string Run()
        {
            Printer.Print("Enter username");
            var username = Console.ReadLine();
            var usernameExist = new UserExists(UserReadRepository).Handle(new UserExists.Query(username));
            if (!usernameExist) return "Username not found !";
            UserWriteRepository.SetConnectedUserId(username);
            return $"Welcome {username}";

        }
    }
}