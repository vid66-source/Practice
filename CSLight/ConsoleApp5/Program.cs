using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ConsoleApp5;

class Program
{
    static void Main(string[] args)
    {
        Cycle cycle = new Cycle();
        string name = "";
        string surName = "";
        string rank = "";
        string password = "";
        string menuItem = "";
        string passwordCheck = "";

        // cycle.PrintNumbers();

        Console.WriteLine("Enter your personal details, soldier.");
        Console.WriteLine("1 - Set Name");
        Console.WriteLine("2 - Set Surname");
        Console.WriteLine("3 - Set Rank");
        Console.WriteLine("4 - Set Password");
        Console.WriteLine("5 - Show Personal Information (requires password)");
        Console.WriteLine("Type \"ESC\" to exit the program.");
        Console.WriteLine("Choose a menu option:");


        while (menuItem != "ESC")
        {

            menuItem = Console.ReadLine();

            if (menuItem == "ESC")
            {
                break;
            }

            switch (menuItem)
            {
                case "1":
                    Console.WriteLine("You have selected item 1. Enter your name:");
                    name = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("You have selected item 2. Enter your surname:");
                    surName = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("You have selected item 3. Enter your rank:");
                    rank = Console.ReadLine();
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have selected item 4. Enter your password:");
                    password = Console.ReadLine();
                    Console.ResetColor();
                    break;
                case "5":
                    Console.WriteLine("Enter your password to view your personal information:");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    passwordCheck = Console.ReadLine();
                    if (passwordCheck == password)
                    {
                        Console.WriteLine($"Name - {name}\nSurname - {surName}\nRank - {rank}");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password");
                    }
                    Console.ResetColor();
                    break;
                default:
                    Console.WriteLine($"{menuItem} is not supported.");
                    break;
            }

            Console.WriteLine("The request has been processed. Choose next action.");
        }
    }
}
