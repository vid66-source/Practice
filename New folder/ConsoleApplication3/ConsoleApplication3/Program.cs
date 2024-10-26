using System;

namespace ConsoleApplication3
{
    internal class Program
    {
        static void Main(string[] args) {
            Vector2 a = new Vector2(14, 89);
            Vector2 b = new Vector2(14);
            // a.X = 14;
            // a.Y = 88;
            a.Print();
            b.Print();
        }
    }

    struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y = 88) {
            X = x;
            Y = y;
        }

        // public Vector2(int x) {
        //     X = x;
        //     Y = 88;
        // }
        
        public void Print() {
            Console.WriteLine($"{X} / {Y}");
        }
    }
}
