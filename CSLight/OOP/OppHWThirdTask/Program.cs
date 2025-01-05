using System.Linq.Expressions;
using System.Security.AccessControl;

namespace OppHWThirdTask;

class Program
{
    static void Main(string[] args)
    {
        Renderer renderer = new Renderer();
        Player player = new Player(-200, 1, '9');

        char[,] map1 = Map.PublicMapCopy(Map.ReadMapFromFile("map2"));

        renderer.DrawMap(map1);
        renderer.DrawPlayer(player.X, player.Y, player.Symbol);
        Console.ReadKey();
    }
}

class Player
{
    public char Symbol { get; private set; }
    private int _x, _y;
    public int X
    {
        get { return _x; }
        set
        {
            if (value >= 1)
                _x = value;
            else
            {
                int cursorLeft = Console.CursorLeft;
                int cursorTop = Console.CursorTop;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Number must be greater than 1.");
                Console.SetCursorPosition(cursorLeft, cursorTop);
                _x = 1;
            }
        }
    }
    public int Y
    {
        get { return _y; }
        private set
        {
            if (value > 1)
                _y = value;
            else
                _y = 1;
        }
    }

    public Player(int x, int y, char symbol)
    {
        X = x;
        Y = y;
        Symbol = symbol;
    }

}

class Map
{
    public string MapName { get; private set; }

    public Map(string mapName)
    {
        MapName = mapName;
    }

    public static char[,] ReadMapFromFile(string mapName)
    {
        string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
        char[,] map = new char[newFile.Length, newFile[0].Length];
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = newFile[i][j];
            }
        }
        return map;
    }

    public static char[,] PublicMapCopy(char[,] map)
    {
        char[,] mapCopy = new char[map.GetLength(0), map.GetLength(1)];
        for (int i = 0; i < mapCopy.GetLength(0); i++)
        {
            for (int j = 0; j < mapCopy.GetLength(1); j++)
            {
                mapCopy[i, j] = map[i, j];
            }
        }
        return mapCopy;
    }

}

class Renderer
{
    public void DrawPlayer(int y, int x, char symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(symbol);
    }

    public void DrawMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }
}
