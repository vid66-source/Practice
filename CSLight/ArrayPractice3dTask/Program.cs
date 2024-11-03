using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArraysPractice;

class Program
{
    static void Main(string[] args)
    {
        int localMax = int.MinValue;
        int[] ints = new int[30];
        Random rand = new Random();

        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] = rand.Next(0, 25);
            Console.Write(ints[i] + " ");
        }
        Console.WriteLine();
        for (int i = 0; i < ints.Length; i++)
        {
            if (i >= 1)
            {
                if (ints[i] > ints[i - 1] && ints[i] > ints[i + 1])
                {
                    localMax = ints[i];
                    Console.Write(localMax + " ");
                }
            }
        }
    }
}
