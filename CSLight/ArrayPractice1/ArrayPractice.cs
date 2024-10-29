using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayPractice1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ints = { { 5, 4, 5, 2, 3, 73, 5 }, { 5, 16, 1, 3, 13, 1, 31 }, { 66, 6, 54, 48, 8, 4, 8 } };

            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    Console.Write(ints[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}