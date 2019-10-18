using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    static class Terminal
    {
        private const string EXIT_ACTION = "exit";
        private const string HELP_ACTION = "?";
        private const string WRONG_MESSAGE = "Wrong input. If you need help, type '?'\n";
        private const string HELP_MESSAGE =
            "\"?\" - for help\n" +
            "\"exit\" - for exit\n" +
            "";


        public static void start()
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    if (EXIT_ACTION.Equals(input))
                        return;
                    else if (HELP_ACTION.Equals(input))
                        Console.WriteLine(HELP_MESSAGE);
                    else if (!Parser.tryParse(input))
                        Console.WriteLine(WRONG_MESSAGE);
                }
            }
        }
    }
}