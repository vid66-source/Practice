using System;

namespace ConsoleApp7;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter yor name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter any symbol");
        string symbol = Console.ReadLine();
        Console.WriteLine();
        for (int i = 0; i < (name.Length + 2); i++)
        {
            Console.Write(symbol);
        }
        Console.WriteLine("\n"+ symbol + name + symbol);
        for (int i = 0; i < (name.Length + 2); i++)
        {
            Console.Write(symbol);
        }
    }
}
