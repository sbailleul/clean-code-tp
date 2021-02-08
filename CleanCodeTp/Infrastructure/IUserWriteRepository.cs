using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface IUserWriteRepository
    {
        Task Create(UserEntity user);
    }
}