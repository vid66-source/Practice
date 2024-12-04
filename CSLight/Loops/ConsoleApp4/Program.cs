using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp4;

class Program
{
    static void Main(string[] args)
    {
        float usd = 200.10f;
        float eur = 120.70f;
        float uah = 500.90f;
        string action = "";
        float usdToEur = 0.92f;
        float eurToUsd = 1.11f;
        float usdToUah = 41.31f;
        float uahToUsd = 0.024f;
        float eurToUah = 44.81f;
        float uahToEur = 0.022f;
        float sumToConvert;
        float resultSum;



        Console.WriteLine($"You have {usd:F2} USD, {eur:F2} EUR and {uah:F2} UAH on your account");

        while (action != "Exit")
        {
            Console.WriteLine("Choose the conversion in the format \"USD to UAH\" or type \"Exit\" to quit:");
            action = Console.ReadLine();

            if (action == "Exit")
            {
                Console.WriteLine("Turning off the program...");
                break;
            }

            Console.WriteLine("Enter the amount of currency you want to exchange");
            sumToConvert = Convert.ToSingle(Console.ReadLine());

            switch (action)
            {
                case "USD to UAH":
                    if (usd > 0 && sumToConvert <= usd)
                    {
                        resultSum = sumToConvert * usdToUah;
                        uah += resultSum;
                        usd -= sumToConvert;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough USD currency on your account");
                    }
                    break;
                case "UAH to USD":
                    if (uah > 0 && sumToConvert <= uah)
                    {
                        resultSum = sumToConvert * uahToUsd;
                        usd += resultSum;
                        uah -= sumToConvert;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough UAH currency on your account");
                    }
                    break;
                case "EUR to USD":
                    if (eur > 0 && sumToConvert <= eur)
                    {
                        resultSum = sumToConvert * eurToUsd;
                        usd += resultSum;
                        eur -= sumToConvert;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough EUR currency on your account");
                    }
                    break;
                case "USD to EUR":
                    if (usd > 0 && sumToConvert <= usd)
                    {
                        resultSum = sumToConvert * usdToEur;
                        eur += resultSum;
                        usd -= sumToConvert;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough USD currency on your account");
                    }
                    break;
                case "UAH to EUR":
                    if (uah > 0 && sumToConvert <= uah)
                    {
                        resultSum = sumToConvert * uahToEur;
                        eur += resultSum;
                        uah -= sumToConvert;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough UAH currency on your account");
                    }
                    break;
                case "EUR to UAH":
                    if (eur > 0 && sumToConvert <= eur)
                    {
                        resultSum = sumToConvert * eurToUah;
                        uah += resultSum;
                        eur -= sumToConvert;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough EUR currency on your account");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid conversion type. Please try again."); // Повідомлення про невірний тип обміну
                    break;
            }
                    Console.WriteLine($"Your updated balance: {usd:F2} USD, {eur:F2} EUR, {uah:F2} UAH.");
        }
    }
}

