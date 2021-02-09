using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CleanCodeTp.Domain.Books;

namespace CleanCodeTp.Domain.Users
{
    public class Member : IUser
    {
        public const int BorrowMaxLimit = 3;
        public const int BorrowMinLimit = 0;

        public Member(UserIdentifier identifier, IList<BookBorrow>? borrowedBooks = null)
        {
            Identifier = identifier;
            BorrowedBooks = borrowedBooks ?? new List<BookBorrow>();
        }

        public UserType Type => new UserType(nameof(Member));

        public UserIdentifier Identifier { get; }

        public IList<BookBorrow> BorrowedBooks { get; }

        protected bool Equals(Member other)
        {
            return Identifier.Equals(other.Identifier) && BorrowedBooks.Equals(other.BorrowedBooks);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Member) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Identifier, BorrowedBooks);
        }

        public BookBorrow BorrowBook(Book book)
        {
            var bookBorrow = new BookBorrow(DateTime.Now, book);
            BorrowedBooks.Add(bookBorrow);
            return bookBorrow;
        }
        
        public void ReturnBook(BookTitle title)
        {
            var borrow = BorrowedBooks.FirstOrDefault(book => book.Book.Title.Equals(title));
            if (borrow is not null) BorrowedBooks.Remove(borrow);
        }

        public bool CanBorrowBook() => BorrowedBooks.Count < BorrowMaxLimit;

        public bool CanReturnBook(BookTitle bookTitle) =>
            BorrowedBooks.Any(borrow => borrow.Book.Title.Equals(bookTitle));

        public bool CanReturnBook() => BorrowedBooks.Count > BorrowMinLimit;
    }
}