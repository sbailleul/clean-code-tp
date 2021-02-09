using System.Collections.Generic;
using System.Linq;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Domain;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;

namespace CleanCodeTp.Application.Extensions
{
    public static class LibraryExtensions
    {
        public static UserEntity ToUserEntity(this IUser user) =>
            new UserEntity(user.Type.TypeName, user.Identifier.Identifier );

        public static UserEntity ToUserEntity(this Member member) => new UserEntity(
            member.Type.TypeName,
            member.Identifier.Identifier,
            member.BorrowedBooks
                .Select(borrow => borrow.ToBorrowedBookEntity(member))
                .ToList()
        );

        public static BookEntity ToBookEntity(this Book book) =>
            new BookEntity(book.BookAuthor.Author, book.Title.Title);

        public static BookBorrowEntity ToBorrowedBookEntity(this BookBorrow borrow, IUser user) =>
            new(borrow.BorrowDate, user.Identifier.Identifier, borrow.Book.Title.Title);

        public static BookBorrowEntity ToBorrowedBookEntity(this BookBorrow borrow, string username) =>
            new(borrow.BorrowDate, username, borrow.Book.Title.Title);
    }
}