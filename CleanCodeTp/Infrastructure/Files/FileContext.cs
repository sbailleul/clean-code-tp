using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure.Files
{
    public class FileContext : IContext
    {
        public static FileContext Instance => _instance ??= new FileContext();

        private static FileContext? _instance;
        private const string PersistenceFileName = "./library.json";


        public LibraryEntity Library { get; set; } = new LibraryEntity();
        public IList<UserEntity> Users => Library.Users;
        public IList<BookEntity> Books => Library.Books;
        public IList<BookBorrowEntity> BookBorrows => Library.Users.SelectMany(user => user.BookBorrows).ToList();
        public string? ConnectedUserId { get; set; }

        public  void Init()
        {
            try
            {
                var fileContent = File.ReadAllText(PersistenceFileName);
                Library =  JsonSerializer.Deserialize<LibraryEntity>(fileContent) ??
                          new LibraryEntity();
            }
            catch (Exception e)
            {
                Library = new LibraryEntity();
                Save();
            }
        }


        public void Save()
        {
            File.WriteAllText(PersistenceFileName, JsonSerializer.Serialize(Library));
        }
    }
}