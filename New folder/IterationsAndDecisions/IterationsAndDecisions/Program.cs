using System;
using System.Linq;

/*namespace IterationsAndDecisions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinqQueryOverlnts();
        }
        static void LinqQueryOverlnts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write ("{0}\n", i);
            }
        }

    }
}*/
namespace Arrays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Arrays();
        }

        static void Arrays()
        {
            int[,,] mas = { { { 1, 2 },{ 3, 4 } }, 
                { { 4, 5 }, { 6, 7 } }, 
                { { 7, 8 }, { 9, 10 } }, 
                { { 10, 11 }, { 12, 13 } }
            }
        }
    }
}