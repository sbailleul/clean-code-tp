using System;
using System.Collections;
using System.Collections.Generic;
using CleanCodeTp.Domain.Books;

namespace CleanCodeTp.Domain.Users
{
    public class Member : IUser
    {
        public const int BorrowLimit = 3;
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

        public bool CanBorrowBook() => BorrowedBooks.Count == BorrowLimit;
    }
}