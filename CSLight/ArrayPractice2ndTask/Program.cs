using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArraysPractice;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        int maxInt = int.MinValue;
        int maxRow = 0;
        int maxCol = 0;

        int[,] ints = new int[10, 10];

        for (int i = 0; i < ints.GetLength(0); i++)
        {
            for (int j = 0; j < ints.GetLength(1); j++)
            {
                ints[i, j] = rand.Next(0, 100);
                if (j == 5)
                {
                    ints[i, j] = rand.Next(100, 1000);
                }

                if (ints[i, j] > maxInt)
                {
                    maxInt = ints[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }
        Console.WriteLine("The largest number of the array is equal to " + maxInt);
        Console.WriteLine("First array without changes:");

        for (int i = 0; i < ints.GetLength(0); i++)
        {
            for (int j = 0; j < ints.GetLength(1); j++)
            {
                Console.Write(ints[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Second array with 0 value instead of largest number in it:");

        ints[maxRow, maxCol] = 0;

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
