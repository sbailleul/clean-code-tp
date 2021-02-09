using System;
using System.Reflection;
using System.Threading.Tasks;
using CleanCodeTp.Infrastructure.Files;

namespace CleanCodeTp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileContext.Instance.Init();

            var application = new Ui.Application();
            application.Run();
        }
    }
}