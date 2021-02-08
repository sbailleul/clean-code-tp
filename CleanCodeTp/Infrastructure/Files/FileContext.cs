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
        public static FileContext Instance => _instance ?? new FileContext();
        private static readonly FileContext? _instance = null;
        private string PersistenceFileName => "./library.txt";


        public LibraryEntity Library { get; set; } = new LibraryEntity();
        public IList<UserEntity> Users => Library.Users;
        public IList<BookEntity> Books => Library.Books;
        public IList<BookBorrowEntity> BookBorrows => Library.Users.SelectMany(user => user.BookBorrows).ToList();
        
        public async Task Init()
        {
            await using var persistenceFileStream = File.Open(Instance.PersistenceFileName, FileMode.OpenOrCreate);
            try
            {
                Library = await JsonSerializer.DeserializeAsync<LibraryEntity>(persistenceFileStream) ?? new LibraryEntity();
            }
            catch (Exception e)
            {
                Library = new LibraryEntity();
            }
        }


        public async Task Save()
        {
            await using var persistenceFileStream = File.Open(Instance.PersistenceFileName, FileMode.Create);
            await JsonSerializer.SerializeAsync(persistenceFileStream, Library);
        }
    }
}