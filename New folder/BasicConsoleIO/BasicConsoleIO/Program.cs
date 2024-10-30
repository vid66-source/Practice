using System;
using System.Runtime.InteropServices;

namespace BasicConsoleIO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*** Basic Console I/O ***");
            FormatNumericalData();
        }
        
        static void FormatNumericalData()
        {
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d5 format: {0:d5}", 99999);
            Console.WriteLine("f5 format: {0:f5}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
            Console.ReadLine();
        }
    }
}