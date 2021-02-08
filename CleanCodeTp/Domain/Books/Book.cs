
using System;

namespace CleanCodeTp.Domain.Books
{
    public record Book
    {
        public virtual bool Equals(Book? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title.Equals(other.Title) && BookAuthor.Equals(other.BookAuthor);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, BookAuthor);
        }

        public Book(BookTitle title, BookAuthor bookAuthor)
        {
            Title = title;
            BookAuthor = bookAuthor;
        }

        public BookTitle Title { get; }
        public BookAuthor BookAuthor { get; }


    }
}