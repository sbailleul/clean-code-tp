using System;
using System.Threading.Tasks;
using CleanCodeTp.Application;
using CleanCodeTp.Application.UsesCases;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp.Ui
{
    class Application
    {
        public async Task Run()
        {
            
            IHandler<AddBookReference.AddBookCommand, Task> useCase = new AddBookReference(new LibraryReadRepository(), new BookWriteRepository());
            var test = new LibraryReadRepository();
            var res =  test.Load();
            Console.WriteLine(res);
            
        }
    }
}