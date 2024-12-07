namespace queueInAStore;

class Program
{
    static void Main(string[] args)
    {
        Random custumersMoney = new Random();
        Queue<int> custumersQueue = new Queue<int>();
        int salesSum = 0;

        GivingMoney(custumersQueue, custumersMoney);
        StoreEarnMoney(custumersQueue, ref salesSum);
    }

    static void GivingMoney(Queue<int> custumers, Random random)
    {
        for (int i = 0; i < 10; i++)
        {
            int custumerMoney = random.Next(100, 1000);
            custumers.Enqueue(custumerMoney);
        }
    }

    static void StoreEarnMoney(Queue<int> queue, ref int salesSum)
    {
        int customerNumber = 1;

        while (queue.Count != 0)
        {
            int sale = queue.Dequeue();
            salesSum += sale;

            Console.WriteLine($"Customer #{customerNumber} left {sale} UAH in the cash register.");
            Console.WriteLine($"Total in the cash register: {salesSum} UAH.");
            customerNumber++;

            Console.WriteLine("\nPress any key to serve the next customer...");
            Console.ReadKey();
            Console.Clear();
        }

        Console.WriteLine("All customers have been served!");
    }
}
