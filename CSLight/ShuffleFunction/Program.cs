namespace ShuffleFunction;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        char[] charArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q' };

        ShuffleArray(random, charArray);

        for (int i = 0; i < charArray.Length; i++)
        {
            Console.Write($"{charArray[i]} ");
        }

        Console.ReadKey();
    }

    static void ShuffleArray(Random random, char[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);

            // Обмін елементів
            char temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
