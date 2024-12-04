// using System;

// namespace CurrencyConverter
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Ініціалізація початкових балансів користувача
//             float usd = 200.10f;
//             float eur = 120.70f;
//             float uah = 500.90f;

//             // Визначення курсів обміну
//             float usdToEur = 0.92f; // 1 USD = 0.92 EUR
//             float eurToUsd = 1.11f; // 1 EUR = 1.11 USD
//             float usdToUah = 41.31f; // 1 USD = 41.31 UAH
//             float uahToUsd = 0.024f; // 1 UAH = 0.024 USD
//             float eurToUah = 44.81f; // 1 EUR = 44.81 UAH
//             float uahToEur = 0.022f; // 1 UAH = 0.022 EUR

//             // Виведення початкового балансу
//             Console.WriteLine($"You have {usd:F2} USD, {eur:F2} EUR, and {uah:F2} UAH on your account.");

//             // Основний цикл програми
//             while (true)
//             {
//                 // Запит на вибір валюти для обміну або завершення програми
//                 Console.WriteLine("Choose the conversion in the format \"USD to UAH\" or type \"Exit\" to quit:");
//                 string action = Console.ReadLine();

//                 // Якщо користувач ввів "Exit", виходимо з програми
//                 if (action == "Exit")
//                 {
//                     Console.WriteLine("Exiting the program...");
//                     break; // Вихід з циклу
//                 }

//                 // Запит на введення суми для обміну
//                 Console.WriteLine("Enter the amount you want to convert:");
//                 string inputAmount = Console.ReadLine(); // Зчитуємо введене значення

//                 // Спробуємо перетворити введене значення в число
//                 float amount;
//                 bool isValidAmount = float.TryParse(inputAmount, out amount);

//                 // Перевірка, чи сума валідна та позитивна
//                 if (!isValidAmount || amount <= 0)
//                 {
//                     Console.WriteLine("Invalid amount. Please enter a positive number."); // Повідомлення про помилку
//                     continue; // Повернення до початку циклу
//                 }

//                 // Виконання конверсії в залежності від введеної команди
//                 switch (action)
//                 {
//                     case "USD to UAH":
//                         // Перевірка, чи достатньо USD для обміну
//                         if (usd >= amount)
//                         {
//                             uah += amount * usdToUah; // Обчислення нової суми UAH
//                             usd -= amount; // Вирахування суми з USD
//                         }
//                         else
//                         {
//                             Console.WriteLine("You don't have enough USD."); // Повідомлення про недостатність
//                         }
//                         break;

//                     case "UAH to USD":
//                         // Перевірка, чи достатньо UAH для обміну
//                         if (uah >= amount)
//                         {
//                             usd += amount * uahToUsd; // Обчислення нової суми USD
//                             uah -= amount; // Вирахування суми з UAH
//                         }
//                         else
//                         {
//                             Console.WriteLine("You don't have enough UAH."); // Повідомлення про недостатність
//                         }
//                         break;

//                     case "EUR to USD":
//                         // Перевірка, чи достатньо EUR для обміну
//                         if (eur >= amount)
//                         {
//                             usd += amount * eurToUsd; // Обчислення нової суми USD
//                             eur -= amount; // Вирахування суми з EUR
//                         }
//                         else
//                         {
//                             Console.WriteLine("You don't have enough EUR."); // Повідомлення про недостатність
//                         }
//                         break;

//                     case "USD to EUR":
//                         // Перевірка, чи достатньо USD для обміну
//                         if (usd >= amount)
//                         {
//                             eur += amount * usdToEur; // Обчислення нової суми EUR
//                             usd -= amount; // Вирахування суми з USD
//                         }
//                         else
//                         {
//                             Console.WriteLine("You don't have enough USD."); // Повідомлення про недостатність
//                         }
//                         break;

//                     case "UAH to EUR":
//                         // Перевірка, чи достатньо UAH для обміну
//                         if (uah >= amount)
//                         {
//                             eur += amount * uahToEur; // Обчислення нової суми EUR
//                             uah -= amount; // Вирахування суми з UAH
//                         }
//                         else
//                         {
//                             Console.WriteLine("You don't have enough UAH."); // Повідомлення про недостатність
//                         }
//                         break;

//                     case "EUR to UAH":
//                         // Перевірка, чи достатньо EUR для обміну
//                         if (eur >= amount)
//                         {
//                             uah += amount * eurToUah; // Обчислення нової суми UAH
//                             eur -= amount; // Вирахування суми з EUR
//                         }
//                         else
//                         {
//                             Console.WriteLine("You don't have enough EUR."); // Повідомлення про недостатність
//                         }
//                         break;

//                     default:
//                         Console.WriteLine("Invalid conversion type. Please try again."); // Повідомлення про невірний тип обміну
//                         continue; // Повернення до початку циклу
//                 }

//                 // Виведення оновленого балансу
//                 Console.WriteLine($"Your updated balance: {usd:F2} USD, {eur:F2} EUR, {uah:F2} UAH.");
//             }
//         }
//     }
// }
