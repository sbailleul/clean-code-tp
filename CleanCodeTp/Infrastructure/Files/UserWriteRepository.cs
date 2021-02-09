using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    class UserWriteRepository : IUserWriteRepository
    {
        public void Create(UserEntity user)
        {
            FileContext.Instance.Users.Add(user);
            FileContext.Instance.Save();
        }

        public void SetConnectedUserId(string? userId)
        {
            FileContext.Instance.ConnectedUserId = userId;
        }

        public void AddBorrowedBookToUser(string commandUsername, BookBorrowEntity bookBorrowEntity)
        {
            FileContext.Instance.Users
                .FirstOrDefault(user => user.Username == commandUsername)?.BookBorrows
                .Add(bookBorrowEntity);
            FileContext.Instance.Save();
        }

        public void RemoveBorrowedBookToUser(string commandUsername, string bookTitle)
        {
            var foundUser = FileContext.Instance.Users.FirstOrDefault(user => user.Username == commandUsername);
            if (foundUser is null) return;

            var bookBorrowEntity =  foundUser.BookBorrows.FirstOrDefault(borrow => borrow.BookTitle == bookTitle);
            if (bookBorrowEntity != null) foundUser.BookBorrows.Remove(bookBorrowEntity);
            FileContext.Instance.Save();
        }
    }
}