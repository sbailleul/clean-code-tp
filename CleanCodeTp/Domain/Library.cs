using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;

namespace CleanCodeTp.Domain
{
    public class Library
    {
        public Library(Librarian librarian, ISet<Book> books, ISet<Guest> guests, ISet<Member> members)
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
            userIdentifier == Librarian?.Identifier || Members.Any(member => member.Identifier == userIdentifier); 
        public bool CanSetLibrarian(Librarian librarian) => Librarian == null;
        
        public bool UserCanAddBook(UserIdentifier userIdentifier) => userIdentifier == Librarian?.Identifier ;
        public bool UserCanBorrowBook(UserIdentifier userIdentifier)
        {
            var foundMember = Members.FirstOrDefault(member => member.Identifier == userIdentifier);
            if (foundMember == null) return false;
            return foundMember.CanBorrowBook();
        }
        public void AddBook(Book book) => Books.Add(book);

        public void SetLibrarian(Librarian librarian) => Librarian = librarian;

        public void BorrowBook(UserIdentifier userIdentifier, BookTitle bookTitle)
        {
            var foundMember = Members.FirstOrDefault(member => member.Identifier.Equals(userIdentifier));
            var foundBook = Books.FirstOrDefault(book => book.Title.Equals(bookTitle));
            if (foundMember == null || foundBook == null) return;
            
            foundMember.BorrowedBooks.Add(foundBook);
        }
    }
}