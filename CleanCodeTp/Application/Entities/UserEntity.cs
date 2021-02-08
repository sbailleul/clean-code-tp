using System.Collections.Generic;

namespace CleanCodeTp.Application.Entities
{
    public class UserEntity
    {
        public UserEntity(string userType, string username, IList<BookBorrowEntity>? bookBorrows = null)
        {
            UserType = userType;
            Username = username;
            BookBorrows = bookBorrows ?? new List<BookBorrowEntity>();
        }

        public string UserType { get; set; }
        public string Username { get; set; }
        public IList<BookBorrowEntity> BookBorrows { get; set; }
    }
}