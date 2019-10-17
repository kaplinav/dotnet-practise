/*
Рассматривается работа с многомерными массивами: зубчатыми массивами и
прямоугольными.
Обратите внимание на инициализацию элементов массива в том и другом случае
На примере матричного умножения измеряется время работы с массивами
*/
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
            const int N = 1000;
            // Объект–генератор случайных чисел
            Random r = new Random();
            // Объект-секундомер
            Stopwatch sw1 = new Stopwatch();
            // Зубчатые массивы (массивы массивов)
            int[][] A, B, C;
            A = new int[N][];
            B = new int[N][];
            C = new int[N][];

            sw1.Start();
            for (int i = 0; i < N; i++)
            {
                A[i] = new int[N];
                B[i] = new int[N];
                C[i] = new int[N];
                for (int j = 0; j < N; j++)
                {
                    A[i][j] = (int)(r.NextDouble() * 10);
                    B[i][j] = (int)(r.NextDouble() * 10);
                }
            }
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        C[i][j] += A[i][k] * B[k][j];
            sw1.Stop();
            // Прямоугольные массивы
            var sw2 = new Stopwatch();
            sw2.Start();
            int[,] D, E, F;
            D = new int[N, N];
            E = new int[N, N];
            F = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    D[i, j] = (int)(r.NextDouble() * 10);
                    E[i, j] = (int)(r.NextDouble() * 10);
                }
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        F[i, j] += D[i, k] * E[k, j];
            sw2.Stop();
            // Вывод статистики
            Console.WriteLine("Jagged-arrays: {0}, Rect-arrays: {1}",
            sw1.Elapsed.TotalMilliseconds,
           sw2.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }
    }
}