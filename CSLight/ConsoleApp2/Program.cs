using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            string message;

            Console.WriteLine("Enter the number how much times you want to see message:");
            count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your message:");
            message = Console.ReadLine();

            for (int i = count; i > 0; i--)
            {
                Console.WriteLine(message + i);
            }
        }
    }
}
