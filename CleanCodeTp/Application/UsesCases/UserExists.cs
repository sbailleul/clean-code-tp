using System.Linq;
using System.Runtime.CompilerServices;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.UsesCases
{
    public class UserExists : IHandler<UserExists.Query, bool>
    {
        private readonly IUserReadRepository _userReadRepository;

        public class Query
        {
            public Query(string? userId)
            {
                UserId = userId;
            }

            public string? UserId { get; }
        }

        public UserExists(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }


        public bool Handle(Query message)
        {
            return _userReadRepository.GetAll().FirstOrDefault(user => user.Username == message.UserId) != null;
        }
    }
}