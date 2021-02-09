using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Application.UsesCases
{
    public class CreateUser : INoReturnHandler<CreateUser.Command>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public record Command
        {
            public Command(string? username, string type)
            {
                Username = username;
                Type = type;
            }

            public string Username { get; }
            public string Type { get; }
        }

        public CreateUser(ILibraryReadRepository libraryReadRepository, IUserWriteRepository userWriteRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public void Handle(Command message)
        {
            var userId = new UserIdentifier(message.Username);
            var userType = new UserType(message.Type);
            var library = _libraryReadRepository.Load().ToLibrary();
            if (!library.CanCreateUser(userId, userType)) throw new ApplicationException("Can't create user");

            library.SetUser(userId, userType);
            _userWriteRepository.Create(new UserEntity(userType.TypeName, userId.Identifier));
        }
    }
}