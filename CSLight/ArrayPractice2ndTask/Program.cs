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

        int arrayElement = 0;
        int maxInt = 0;

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
                Console.Write(ints[i, j] + " ");
                arrayElement = ints[i, j];
                if (arrayElement > maxInt)
                {
                    maxInt = arrayElement;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("The largest number of the array is equal to " + maxInt);
    }
}
