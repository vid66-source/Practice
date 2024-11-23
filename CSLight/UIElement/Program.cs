using System;

namespace UIElement;

class Program
{
    static string input = null;
    static int barPercent;

    static void Main(string[] args)
    {
        Console.Write("Enter %(from 0 to 100). The number must be a multiple of ten:");
        input = Console.ReadLine();
        Console.SetCursorPosition(0, 5);

        if (int.TryParse(input, out barPercent) && barPercent > 0 && barPercent < 100)
        {
            if (int.TryParse(input, out int barPercent) && barPercent >= 0 && barPercent <= 100 && barPercent % 10 == 0)
            {
                Console.Write("[");
                BarVisualisation(barPercent / 10);
                Console.Write("]");
            }
            else
            {
                Console.WriteLine("Invalid number format.");
            }
            Console.ReadKey();
        }
    }

    static void BarVisualisation(int percent)
    {
        const int totalBars = 10;
        for (int i = 0; i < totalBars; i++)
        {
            if (i < percent)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('_');
            }
        }
    }
}
