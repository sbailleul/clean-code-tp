using System;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Ui.OptionAction
{
    public class ListAllBooksActions: IOptionAction
    {
        public ILibraryReadRepository LibraryReadRepository { get; }

        public IBookReadRepository BookReadRepository { get; }
        
        public IUserReadRepository UserReadRepository { get; }

        public ListAllBooksActions(ILibraryReadRepository libraryReadRepository, IBookReadRepository bookReadRepository, IUserReadRepository userReadRepository)
        {
            LibraryReadRepository = libraryReadRepository;
            BookReadRepository = bookReadRepository;
            UserReadRepository = userReadRepository;
        }

        public string Run()
        {
            var listBook = new ListBooks(LibraryReadRepository,BookReadRepository);
            if (!listBook.IsAuthorized(UserReadRepository.GetConnectedUserId()))
            {
                return "You are not authorized to list all books of library";
            }

            return listBook.Handle().ToString() ?? string.Empty;
        }
    }
}