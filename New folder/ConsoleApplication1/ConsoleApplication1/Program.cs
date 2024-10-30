using System;

namespace ConsoleApplication1
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hello World");
            Console.WriteLine();
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine("Args: {0}", arg);
            ShowEnvironmentDetails();
            
            Console.ReadLine();
            return -1;
        }

        static void ShowEnvironmentDetails()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            
            foreach (string drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
            Console.WriteLine("Operating System is 64 or not: {0}", Environment.Is64BitOperatingSystem);
            Console.WriteLine("User name: {0}", Environment.UserName);
        }
    }
}
