namespace Dictionary;

class Program
{
    static void Main(string[] args)
    {
        string input = null;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        AddCoupleWords(dictionary);


        while (true)
        {
            Console.WriteLine("Enter the word you are interested in:");

            input = Console.ReadLine();

            foreach (var word in dictionary)
            {
                if (word.Key.ToLower() == input.ToLower())
                {
                    Console.WriteLine($"{word.Key} - {word.Value}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }



    static void AddCoupleWords(Dictionary<string, string> dictionary)
    {
        dictionary.Add("leverage", "the action or advantage of using a lever");
        dictionary.Add("bear", "to accept, tolerate, or endure something, especially something unpleasant");
        dictionary.Add("look", "to direct your eyes in order to see");
        dictionary.Add("address", "a place where someone lives");
    }
}
