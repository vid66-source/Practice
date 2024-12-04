namespace ReadInt;

class Program
{
    static void Main(string[] args)
    {
        string input;
        bool success = false;
        int number;



        while (!success)
        {
            Console.WriteLine("Please, enter a number");
            input = Console.ReadLine();
            if (int.TryParse(input, out number))
            {
                Console.WriteLine($"Conversion succeeded! The number is {number}");
                success = true;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Conversion failed! Input is not a valid integer.");
            }
        }
    }
}
