using System;

namespace CleanCodeTp.Ui
{
    public class Printer: IPrinter

    {
        public void Print(string? content)
        {
            Console.WriteLine(content);
        }
    }
}