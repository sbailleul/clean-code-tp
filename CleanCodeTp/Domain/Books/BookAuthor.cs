using System.Collections.Generic;

namespace CleanCodeTp.Domain.Books
{
    public record BookAuthor
    {
        public BookAuthor(string author)
        {
            Author = author;
        }

        public string Author { get; }

        public virtual bool Equals(BookAuthor? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Author == other.Author;
        }

        public override int GetHashCode()
        {
            return Author.GetHashCode();
        }
    }
}