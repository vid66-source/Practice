using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArraysPractice;

class Program
{
    static void Main(string[] args)
    {
        int[] tables = { 5, 9, 2, 8, 7, 6, 3, 1, 2 };
        bool isOpen = true;

        Console.Clear();
        while (isOpen)
        {
            Console.SetCursorPosition(0, 23);
            for (int i = 0; i < tables.Length; i++)
            {
                Console.WriteLine("Table " + (i + 1) + " has " + tables[i] + " free seats.");
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Cafe administration\n\n1 - Order seat.\n\n2 - Exit\nSelect a menu item:");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    int userTable, userPlace;
                    Console.Write("Which table do you want to choose?:");
                    userTable = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (tables.Length <= userTable || userTable < 0)
                    {
                        Console.WriteLine("Such a table does not exist.");
                    }
                    Console.Write("How many seats at this table do you need?:");
                    userPlace = Convert.ToInt32(Console.ReadLine());
                    tables[userTable] -= userPlace;
                    if (tables[userTable] < userPlace)
                    {
                        Console.WriteLine("There are not enough seats at this table.");
                        break;
                    }
                    break;
                case 2:
                    isOpen = false;
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
