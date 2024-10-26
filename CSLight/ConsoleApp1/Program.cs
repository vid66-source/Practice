using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Program{
        static void Main(string[] args)
        {
            int hrnToUsd = 41, usdToHrn = 43;
            float hrn;
            float usd;
            string userInput;
            float currencyCount;

            
            Console.WriteLine("Welcome to our currency exchange. Here you can exchange hryvnias for dollars and exchange dollars for hryvnias");

            Console.WriteLine("Enter the hryvnia balance");
            hrn = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter your dollar balance");
            usd = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("1 - exchange hryvnias for dollars");
            Console.WriteLine("2 - exchange dollars for hryvnias");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Exchange hryvnias for dollars");
                    Console.WriteLine("How much do you want to exchange:");
                    currencyCount = Convert.ToSingle(Console.ReadLine());
                    if(hrn >= currencyCount)
                    { 
                        hrn -= currencyCount;
                        usd += currencyCount / hrnToUsd;
                    }
                    else
                    {
                        Console.WriteLine("Unable to perform the operation");
                    }
                    break;
                case "2":
                    Console.WriteLine("Dollar to hryvnia exchange");
                    Console.WriteLine("How much do you want to exchange:");
                    currencyCount = Convert.ToSingle(Console.ReadLine());
                    if(hrn >= currencyCount)
                    {
                        usd -= currencyCount;
                        hrn += currencyCount * usdToHrn;
                    }
                    else
                    {
                        Console.WriteLine("Unable to perform the operation");
                    }
                    break;
            }

            Console.WriteLine("Your balance - " + hrn + " hryvnias & " + usd + " dollars.");
        }
    }
}