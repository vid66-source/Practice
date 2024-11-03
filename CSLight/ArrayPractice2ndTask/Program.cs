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

        int maxInt = 0;

        int[,] ints = new int[10, 10];

        for (int i = 0; i < ints.GetLength(0); i++)
        {
            for (int j = 0; j < ints.GetLength(1); j++)
            {
                ints[i, j] = rand.Next(0, 100);
                Console.Write(ints[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
