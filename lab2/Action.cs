using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    static class Action
    {
        public static void createMatrix(string matrixName, string matrixElements)
        {
            Matrix m;
            Matrix.TryParse(matrixElements, out m);

            //Console.WriteLine(
            //    "\n" +
            //    "1 0 0\n" +
            //    "0 1 0\n" +
            //    "0 0 1\n"
            //    );

            int z = 0;
            z = 1;
        }

        public static void showMatrix(string matrixName)
        {
            Console.WriteLine(
                "\n" +
                "1 0 0\n" +
                "0 1 0\n" +
                "0 0 1\n"
                );
        }
    }
}
