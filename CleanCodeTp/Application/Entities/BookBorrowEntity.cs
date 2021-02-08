using System;

namespace CleanCodeTp.Application.Entities
{
    public class BookBorrowEntity
    {
        public BookBorrowEntity(DateTime borrowDate, string username, string bookTitle)
        {
            BorrowDate = borrowDate;
            Username = username;
            BookTitle = bookTitle;
        }

        public DateTime BorrowDate { get; set; }
        public string Username { get; set; }
        public string BookTitle { get; set; }
    }
}