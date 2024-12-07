﻿namespace queueInAStore;

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
        while (queue.Count != 0)
        {
            int sale = queue.Dequeue();
            salesSum += sale;
            Console.WriteLine($"The buyer left the amount of {sale} UAH in the cash register. At the moment, there is {salesSum} UAH in the cash register.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
