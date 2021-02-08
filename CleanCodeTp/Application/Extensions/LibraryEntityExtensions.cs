using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Domain;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.Extensions
{
    public static class LibraryEntityExtensions
    {
        public static Library ToLibrary(this LibraryEntity libraryEntity)
        {
            var books = libraryEntity.Books.Select(b => b.ToBook()).ToHashSet();
            var members = libraryEntity.Users
                .Where(user => user.UserType == nameof(Member))
                .Select(user => user.ToMember(books)).ToHashSet();
            var guests = libraryEntity.Users
                .Where(user => user.UserType == nameof(Guest))
                .Select(user => user.ToGuest()).ToHashSet();
            var librarian = libraryEntity.Users
                .First(user => user.UserType == nameof(Librarian))
                .ToLibrarian();
            return new Library(librarian, books, guests, members);
        }

        static Book ToBook(this BookEntity bookEntity)
            => new(new BookTitle(bookEntity.Title), new BookAuthor(bookEntity.Author));


        static Member ToMember(this UserEntity userEntity, ISet<Book> books)
        {
            var userBorrows = GetUserBorrows(userEntity, books);
            return new Member(new UserIdentifier(userEntity.Username), userBorrows);
        }
        
        static IList<BookBorrow> GetUserBorrows(UserEntity userEntity, ISet<Book> books)
        {
            return userEntity.BookBorrows.Select(borrow =>
            {
                var borrowedBook = books.FirstOrDefault(book => book.Title.Title == borrow.BookTitle);
                if (borrowedBook == null) return null;
                return borrow.ToBookBorrow(borrowedBook);
            }).ToList()!;
        }

        static Guest ToGuest(this UserEntity userEntity) => new Guest(new UserIdentifier(userEntity.Username));

        static Librarian ToLibrarian(this UserEntity userEntity) =>
            new(new UserIdentifier(userEntity.Username));

        static BookBorrow ToBookBorrow(this BookBorrowEntity bookBorrowEntity, Book book) =>
            new(bookBorrowEntity.BorrowDate, book);
    }


}