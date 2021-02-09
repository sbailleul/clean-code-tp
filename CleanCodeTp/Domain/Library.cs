using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;

namespace CleanCodeTp.Domain
{
    public class Library
    {
        public Library(Librarian? librarian, ISet<Book> books, ISet<Guest> guests, ISet<Member> members)
        {
            Librarian = librarian;
            Books = books;
            Guests = guests;
            Members = members;
        }

        private ISet<Book> Books { get; }
        private Librarian? Librarian { get; set; }
        private ISet<Guest> Guests { get; }
        private ISet<Member> Members { get; }

        public bool CanAddBook(Book newBook) => !Books.Any(book => book.Title.Equals(newBook.Title));

        public bool CanListBooks(UserIdentifier userIdentifier) =>
            userIdentifier.Equals(Librarian?.Identifier)  || Members.Any(member => member.Identifier == userIdentifier);

        public bool CanCreateUser(UserIdentifier userId, UserType userType)
        {
            return userType.TypeName switch
            {
                nameof(Users.Librarian) => CanCreateLibrarian(),
                nameof(Member) => CanCreateMember(userId),
                _ => userType.TypeName == nameof(Guest) && CanCreateGuest(userId)
            };
        }

        public bool CanCreateLibrarian() => Librarian == null;
        public bool CanCreateMember(UserIdentifier userId) => !Members.Any(member => member.Identifier.Equals(userId));
        public bool CanCreateGuest(UserIdentifier userId) => !Guests.Any(guest => guest.Identifier.Equals(userId));
        public bool UserCanAddBook(UserIdentifier userIdentifier) => userIdentifier.Equals( Librarian?.Identifier);

        public bool UserCanBorrowBook(UserIdentifier userIdentifier)
        {
            var foundMember = FindMemberById(userIdentifier);
            if (foundMember == null) return false;
            return foundMember.CanBorrowBook();
        }

        public bool UserCanReturnBook(UserIdentifier userIdentifier)
        {
            var foundMember = FindMemberById(userIdentifier);
            if (foundMember == null) return false;

            return foundMember.CanReturnBook();
        }

        public void AddBook(Book book) => Books.Add(book);

        public void SetUser(UserIdentifier userId, UserType userType)
        {
            switch (userType.TypeName)
            {
                case nameof(Users.Librarian):
                    Librarian = new Librarian(userId);
                    break;
                case nameof(Guests):
                    Guests.Add(new Guest(userId));
                    break;
                case nameof(Members):
                    Members.Add(new Member(userId));
                    break;
            }
        }

        public BookBorrow? BorrowBook(UserIdentifier userIdentifier, BookTitle bookTitle)
        {
            var foundMember = FindMemberById(userIdentifier);
            var foundBook = FindBookByTitle(bookTitle);
            if (foundMember == null || foundBook == null) return null;
            return foundMember.BorrowBook(foundBook);
        }

        private Member? FindMemberById(UserIdentifier userIdentifier)
        {
            return Members.FirstOrDefault(member => member.Identifier.Equals(userIdentifier));
        }



        public bool ReturnBook(UserIdentifier userIdentifier, BookTitle bookTitle)
        {
            var foundMember = FindMemberById(userIdentifier);
            var foundBook = FindBookByTitle(bookTitle);
            if (foundMember is null || foundBook is null) return false;
            foundMember.ReturnBook(bookTitle);
            return true;
        }

        private Book? FindBookByTitle(BookTitle bookTitle)
        {
            return Books.FirstOrDefault(book => book.Title.Equals(bookTitle));
        }
    }
}