using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface IUserWriteRepository
    {
        void Create(UserEntity user);
        void AddBorrowedBookToUser(string commandUsername, BookBorrowEntity bookBorrowEntity);
        void RemoveBorrowedBookToUser(string commandUsername, string bookTitle);

        void SetConnectedUserId(string? userId);
    }
}