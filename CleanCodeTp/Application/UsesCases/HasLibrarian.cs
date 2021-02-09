using System;
using System.Linq;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Application.UsesCases
{
    public class HasLibrarian : INoParamHandler<bool>
    {
        private readonly IUserReadRepository _userReadRepository;

        public HasLibrarian(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public bool Handle()
        {
            return _userReadRepository.GetAll().FirstOrDefault(user => user.UserType == nameof(Librarian)) != null;
        }
    }
}