using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using CleanCodeTp.Application;
using CleanCodeTp.Infrastructure;
using CleanCodeTp.Ui.OptionAction;

namespace CleanCodeTp.Ui
{
    public class Option
    {
        public IList<Option>? Options { get; set; }
        public Option? ParentOption { get; }
        public IOptionAction? Action { get; }

        public string Prompt { get; }
        public IPrinter Printer { get; }
        
        public Option(Option? parentOption, IPrinter printer, string prompt,  IOptionAction? action = null,
            IList<Option>? options = null)
        {
            ParentOption = parentOption;
            Action = action;
            Printer = printer;
            Options = options;
            Prompt = prompt;
        }


        public int Run()
        {
            Printer.Print(Action?.Run());
            if (Options?.DefaultIfEmpty() == null)
            {
                return ParentOption?.Run() ?? -1;
            }
            var choice = GetUserChoice();
            if (choice == -1)
            {
                return ParentOption?.Run() ?? -1;
            }
            return Options?[choice].Run() ?? -1;
        }

        private int GetUserChoice()
        {
            Printer.Print("Enter -1 to EXIT");
            var choice = -1;
            for (var i = 0; i < Options?.Count; i++)
            {
                Printer.Print($"{i} : {Options[i].Prompt}");
            }

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice < -1 ||  Options != null && choice >= Options.Count) throw new IndexOutOfRangeException();
            }
            catch (Exception e)
            {
                Printer.Print("Bad input !!!");
                choice = GetUserChoice();
            }
            return choice;
        }
    }
}