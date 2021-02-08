using System.Collections;
using System.Collections.Generic;
using CleanCodeTp.Domain.Books;

namespace CleanCodeTp.Application.Entities
{
    public class LibraryEntity
    {
        public LibraryEntity(IList<BookEntity>? books = null, IList<UserEntity>? users = null)
        {
            Books = books ?? new List<BookEntity>();
            Users = users ?? new List<UserEntity>();
        }

        public IList<BookEntity> Books { get; set; }
        public IList<UserEntity> Users { get; set; }
    }
}