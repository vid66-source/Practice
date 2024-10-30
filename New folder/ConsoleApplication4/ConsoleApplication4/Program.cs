using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication4
{
    internal class Program
    {
        public static void Main(string[] args) {
            Console.WriteLine("Enter 3 sides of triangle");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine($"x = {x}");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine($"y = {y}");
            double z = double.Parse(Console.ReadLine());
            Console.WriteLine($"z = {z}");
            double p = (x + y + z) * 0.5;
            double s = Math.Sqrt(p * (p - x) * (p - y) * (p - z));
            Console.WriteLine($"square of your triangle is {s}");
            Console.ReadLine();
        }

        public void SecondHomework() {
            Console.WriteLine("Enter 3 sides of triangle");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine($"x = {x}");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine($"y = {y}");
            double z = double.Parse(Console.ReadLine());
            Console.WriteLine($"z = {z}");
            double p = (x + y + z) * 0.5;
            double s = Math.Sqrt(p * (p - x) * (p - y) * (p - z));
            Console.WriteLine($"square of your triangle is {s}");
        }
        
        public void FistHomeWork() {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            Console.WriteLine("Enter two numbers");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"You entered num1:{num1} and num2:{num2}");
            int num3;
            num3 = num1;
            num1 = num2;
            num2 = num3;
            Console.WriteLine($"Now num1 is {num1} num2 is {num2}");
            Console.WriteLine();
            Console.WriteLine("Enter integer number with 3 or more numbers");
            string str = Console.ReadLine();
            int strLength = str.Length;
            Console.WriteLine($"Your number has {strLength} numbers");
        }
    }
}