using System.Collections.Generic;

namespace CleanCodeTp.Domain.Books
{
    public record BookTitle
    {
        public BookTitle(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public virtual bool Equals(BookTitle? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title == other.Title;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}