using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    class UserWriteRepository : IUserWriteRepository
    {
        public async Task Create(UserEntity user)
        {
            FileContext.Instance.Users.Add(user);
            await FileContext.Instance.Save();
        }
    }
}