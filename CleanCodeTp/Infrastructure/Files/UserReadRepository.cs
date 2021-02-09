using System.Collections.Generic;
using System.Linq;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    public class UserReadRepository : IUserReadRepository
    {
        public IList<UserEntity> GetAll() => FileContext.Instance.Users;
        public UserEntity? GetById(string id) => FileContext.Instance.Users.FirstOrDefault(user => user.Username == id);
        public string? GetConnectedUserId() => FileContext.Instance.ConnectedUserId;
    }
}