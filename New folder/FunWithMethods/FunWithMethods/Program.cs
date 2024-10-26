using System;

namespace FunWithMethods
{
    internal class Program
    {
        private static void Main(string[] args) {
            Bank();
        }

        private static void Bank() {
            Console.WriteLine("Enter months count:");
            int monthsInput = 0;

            while (monthsInput <= 0) {
                if (int.TryParse(Console.ReadLine(), out monthsInput) && monthsInput > 0) {
                    Console.WriteLine($"You entered {monthsInput}");
                }
                else {
                    Console.WriteLine("You entered wrong value, please try again:");
                }
            }

            Console.WriteLine("Now enter your Sum:");

            float InterSum = 0;

            while (InterSum <= 0) {
                if (float.TryParse(Console.ReadLine(), out InterSum) && InterSum > 0) {
                    Console.WriteLine($"Entered Sum {InterSum}");
                }
                else {
                    Console.WriteLine("You entered wrong value, please try again:");
                }
            }

            for (var i = 0; i <= monthsInput; i++) {
                var Percent = InterSum * 00.7f;
                InterSum += Percent;
                Console.WriteLine($"{InterSum}");
            }
        }
    }
}