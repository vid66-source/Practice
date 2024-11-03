using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArraysPracticeDynamicArray;

class Program
{
    static void Main(string[] args)
    {
        bool check = true;
        int[] ints = new int[0];
        string userInput;
        int elementSum = 0;

        while (check)
        {
            userInput = Console.ReadLine();
            if (userInput != "sum" && userInput != "exit")
            {
                if (ints[0] == 0)
                {
                    ints[0] = Convert.ToInt32(userInput);
                    Console.WriteLine(ints[0]);
                }
                else
                {
                    int[] tempInts = new int[ints.Length + 1];
                    for (int i = 0; i < ints.Length; i++)
                    {
                        tempInts[i] = ints[i];
                    }
                    tempInts[tempInts.Length - 1] = Convert.ToInt32(userInput);
                    ints = tempInts;
                    for (int i = 0; i < ints.Length; i++)
                    {
                        Console.Write(ints[i] + " ");
                    }
                }
            }
            if (userInput == "sum")
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    if (i == 0)
                    {
                        elementSum = ints[i];
                    }
                    else
                    {
                        elementSum = elementSum + ints[i];
                    }
                }
                Console.WriteLine(elementSum);
            }
            if (userInput == "exit")
            {
                check = false;
            }
        }
    }
}
