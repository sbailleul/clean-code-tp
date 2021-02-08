using System;
using System.Reflection;
using System.Threading.Tasks;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await FileContext.Instance.Init();
            
            var application = new Ui.Application();
            await application.Run();
        }
    }
}