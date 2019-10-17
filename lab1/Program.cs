using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace lab1
{
    class Program
    {
        static Type[] builtinTypes = new Type[] {
                typeof(bool),
                typeof(bool),
                typeof(byte),
                typeof(sbyte),
                typeof(char),
                typeof(decimal),
                typeof(double),
                typeof(float),
                typeof(int),
                typeof(uint),
                typeof(long),
                typeof(ulong),
                typeof(object),
                typeof(short),
                typeof(ushort),
                typeof(string)
            };

        static void initialize()
        {
            

        }

        static void printMenu()
        {
            Console.WriteLine(
                "Information about types:\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                "(0) general information about types\n" +
                "(1) select from list\n" +
                "(2) enter type name\n" +
                "(3) console options\n" +
                "(4) exit\n"
                );
        }

        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                printMenu();
                
                switch(Console.ReadKey().KeyChar)
                {
                    case '0': generalInfoShow(); break;
                    case '1': selectFromListShow(); break;
                    case '2': enterTypeNameListShow(); break;
                    case '3': consoleOptionsShow();  break;
                    case '4': return;
                    default: break;
                }   
            }    
        }

        static void generalInfoShow()
        {
            Console.Clear();
            Console.WriteLine("Press any key for main menu");
            Console.ReadKey();
        }

        static void selectFromListShow()
        {
            Console.Clear();
            //Assembly myAssembly = Assembly.GetExecutingAssembly();
            //Type[] thisAssemblyTypes = myAssembly.GetTypes();
            int i = 1;
            for (; i < builtinTypes.Length; i++)
            {
                Console.WriteLine("(" + i + ") " + builtinTypes[i].Name);
            }
            Console.WriteLine("(" + i + ") exit to main menu");

            //string userChoice = Console.ReadLine();
            //if (i.ToString().Equals(userChoice)) return;

            int userChoice = 0;

            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if(userChoice == i)
                {
                    return;
                }
                else
                {

                }
            }
        }

        static void enterTypeNameListShow()
        {

        }

        static void consoleOptionsShow()
        {

        }
    }
}
