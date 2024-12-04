// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace ConsoleApp3
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             int firstNum;
//             int secondNum;
//             int result;
//             string action = "";

//             Console.WriteLine("Welcome to the calculator where you can enter 2 numbers and multiply, divide, add, or subtract.");
//             Console.WriteLine("To exit from the program enter the word \"exit\"");

//             // Основний цикл з чіткою умовою завершення
//             while (action != "exit")
//             {
//                 Console.WriteLine("Which action do you prefer?");
//                 action = Console.ReadLine(); // Зчитуємо дію від користувача

//                 if (action == "exit")
//                 {
//                     Console.WriteLine("Turning off the calculator...");
//                     break; // Виходимо з циклу, якщо введено "exit"
//                 }

//                 // Вводимо перше та друге число лише тоді, коли не вихід
//                 Console.WriteLine("Enter first number:");
//                 firstNum = Convert.ToInt32(Console.ReadLine());

//                 Console.WriteLine("Enter second number:");
//                 secondNum = Convert.ToInt32(Console.ReadLine());

//                 // Обробка дій через switch
//                 switch (action)
//                 {
//                     case "multiply":
//                         result = firstNum * secondNum;
//                         Console.WriteLine(firstNum + " * " + secondNum + " = " + result);
//                         break;
//                     case "divide":
//                         if (secondNum != 0)
//                         {
//                             result = firstNum / secondNum;
//                             Console.WriteLine(firstNum + " / " + secondNum + " = " + result);
//                         }
//                         else
//                         {
//                             Console.WriteLine("Division by zero is not allowed.");
//                         }
//                         break;
//                     case "add":
//                         result = firstNum + secondNum;
//                         Console.WriteLine(firstNum + " + " + secondNum + " = " + result);
//                         break;
//                     case "subtract":
//                         result = firstNum - secondNum;
//                         Console.WriteLine(firstNum + " - " + secondNum + " = " + result);
//                         break;
//                     default:
//                         Console.WriteLine("Invalid action, please enter one of: multiply, divide, add, subtract, or exit.");
//                         break;
//                 }
//             }
//         }
//     }
// }
