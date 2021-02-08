using System.Collections;
using System.Collections.Generic;
using CleanCodeTp.Application.Entities;
using CleanCodeTp.Application.Extensions;
using CleanCodeTp.Domain.Books;
using CleanCodeTp.Domain.Users;
using CleanCodeTp.Infrastructure;

namespace CleanCodeTp.Application.UsesCases
{
    public class ListBooks: INoParamHandler<IList<BookEntity>>, IAuthorizedAction
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IBookReadRepository _bookReadRepository;


        public ListBooks(ILibraryReadRepository libraryReadRepository, IBookReadRepository bookReadRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _bookReadRepository = bookReadRepository;
        }

        public bool IsAuthorized(string username)
        {
            var library =  _libraryReadRepository.Load().ToLibrary();
            return library.CanListBooks(new UserIdentifier(username));
        }
        
        public IList<BookEntity> Handle() => _bookReadRepository.GetAll();
        
    }
}