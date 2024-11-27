namespace ShuffleFunction;

class Program
{
    static void Main(string[] args)
    {
        Random random = new();
        char[] charArray = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'];
        ShuffleArray(random, ref charArray);
        for (int i = 0; i < charArray.Length; i++)
        {
            Console.Write($"{charArray[i]} ");
        }
        Console.ReadKey();
    }

    static void ShuffleArray(Random random, ref char[] array)
    {
        int randomIndex;
        char[] shuffledArray = new char[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            do
            {
                randomIndex = random.Next(0, array.Length);
            } while (shuffledArray[randomIndex] != '\0');
            shuffledArray[randomIndex] = array[i];
        }
        array = shuffledArray;
    }
}
