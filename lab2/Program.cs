using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Terminal().start();

        }
    }
}

class Terminal
{
    private const string EXIT = "exit";
    private const string HELP = "help";
    private const string WRONG_INPUT = "Wrong input. If you need help, type 'help'\n";
    

    public Terminal()
    {

    }

    public void start()
    {
        while (true)
        {
            Console.Write(">");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case EXIT: return;
                case HELP: return; //break;
                default: Console.WriteLine(WRONG_INPUT); break;
            }
        }
    }
}