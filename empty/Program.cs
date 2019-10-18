
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace MatrixMulti
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 3];
            Console.WriteLine(arr.Rank);

            for (int i = 0; i < arr.Rank; i++)
            {
                Console.WriteLine("dimension {0}  from {1} to {2}", i, arr.GetLowerBound(i), arr.GetUpperBound(i));
            }

            
            Console.ReadKey();
        }
    }
}