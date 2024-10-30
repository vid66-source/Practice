using System;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine ("***** Fun with type conversions *****"); // Добавить две переменные типа short и вывести результат,
            short numb1 = 9, numb2 = 10;
            Console.WriteLine($"{numb1} + {numb2} = {Add(numb1, numb2)}");
            string[] newStArray = {"a", "b"};
            newStArray.
                
        }
        static object Add (int x, int y)
        {
            return x + y;
        }
    }

}