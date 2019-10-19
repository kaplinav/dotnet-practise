using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    static class Action
    {
        private static Dictionary<string, Matrix> matrices = new Dictionary<string, Matrix>();

        public static void createMatrix(string matrixName, string matrixElements)
        {
            Matrix parsedMatrix = null;

            // сохранить матрицу под именем matrixName
            if (!Matrix.TryParse(matrixElements, out parsedMatrix) )
            {
                Console.WriteLine("wrong input. matrix was not stored");
                return;
            }

            addToDictionaryMatrix(matrixName, parsedMatrix);    
            Console.WriteLine("matrix {0} was stored", matrixName);
        }

        public static void operationMatrix(string destination, string op1, char operation, string op2)
        {
            Matrix m1;
            if (!matrices.TryGetValue(op1, out m1))
                matrixDoesnotExistMessage(op1);

            Matrix m2;
            if (!matrices.TryGetValue(op2, out m2))
                matrixDoesnotExistMessage(op2);

            Matrix m3 = null;
            switch (operation)
            {
                case '-':
                    m3 = m1 - m2;
                    break;
                case '+':
                    m3 = m1 + m2;
                    break;
                case '*':
                    m3 = m1 * m2;
                    break;
                default: Console.WriteLine("operation {0} does not supported", operation);
                    break;
            }

            addToDictionaryMatrix(destination, m3);
        }

        public static void showMatrix(string matrixName)
        {
            // распечать на консоль матрицу matrixName если сущестует
            Matrix storedMatrix = null;
            if (matrices.TryGetValue(matrixName, out storedMatrix))
                printMatrix(storedMatrix);
            else
                Console.WriteLine("matrix {0} does not exist", matrixName);
        }

        private static void addToDictionaryMatrix(string matrixName, Matrix m)
        {
            if (matrices.ContainsKey(matrixName))
            {
                matrices.Remove(matrixName);
                matrices.Add(matrixName, m);
            }
            else
            {
                matrices.Add(matrixName, m);
            }
        }

        private static void matrixDoesnotExistMessage(string matrixName)
        {
            Console.WriteLine("matrix {0} does not exist", matrixName);
        }

        private static void printMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                string row = null;
                for (int j = 0; j < matrix.Columns; j++)
                    row += " " + matrix[i, j];
                row = row.TrimStart(' ');
                Console.WriteLine(row);
            }
        }
    }
}
