using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp3;

class Program
{
    static void Main(string[] args)
    {
        float firstNum;
        float secondNum;
        float result;
        string action = "";

        Console.WriteLine("Welcome to calculator where you can enter 2 numbers and multiply, divide, add and subtract\nFor exit from the program enter word \"exit\"");

        while (action != "exit")
        {
            Console.WriteLine("Which action do you prefer?");
            action = Console.ReadLine();

            if (action == "exit")
            {
                Console.WriteLine("Calculater is turning off.");
                break;
            }

            Console.WriteLine("Enter first number");
            firstNum = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter second number");
            secondNum = Convert.ToSingle(Console.ReadLine());

            switch (action){
                case "multiply":
                    result = firstNum * secondNum;
                    Console.WriteLine(firstNum + " * " + secondNum + " = " + result);
                    break;
                case "divide":
                    if (secondNum != 0){
                        result = firstNum / secondNum;
                        Console.WriteLine(firstNum + " / " + secondNum + " = " + result);
                    }
                    else{
                        Console.WriteLine("Division by zero is not allowed.");
                    }
                    break;
                case "add":
                    result = firstNum + secondNum;
                    Console.WriteLine(firstNum + " + " + secondNum + " = " + result);
                    break;
                case "substract":
                    result = firstNum + secondNum;
                    Console.WriteLine(firstNum + " - " + secondNum + " = " + result);
                    break;
                default:
                    Console.WriteLine("Invalid action, please enter one of: multiply, divide, add, subtract, or exit.");
                    break;
            }
        }
    }
}
