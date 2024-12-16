namespace OOPPractice4;

class Program
{
    static void Main(string[] args)
    {
        Renderer renderer = new Renderer();
        Player player = new Player(5, 5);

        renderer.DrawPlayer(player.X, player.Y);
        Console.ReadKey();
    }

    class Renderer
    {
        public void DrawPlayer(int x, int y, char c = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }

    class Player
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
