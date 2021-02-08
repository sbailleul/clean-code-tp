using System;

namespace CleanCodeTp.Domain.Books
{
    public record BookBorrow
    {
        public BookBorrow(DateTime borrowDate, Books.Book book)
        {
            BorrowDate = borrowDate;
            Book = book;
        }

        public DateTime BorrowDate { get; }
        public Books.Book Book { get; }

        public virtual bool Equals(BookBorrow? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return BorrowDate.Equals(other.BorrowDate) && Book.Equals(other.Book);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BorrowDate, Book);
        }
    }
}