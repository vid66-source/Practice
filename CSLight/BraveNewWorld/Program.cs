using System.Runtime.CompilerServices;

namespace BraveNewWorld;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        char[,] map = new char[15, 30];
        bool isPlaying = true;
        int heroX = 0;
        int heroY = 0;
        int movedY = 10;
        int movedX = 10;
        int applesCollected = 0;

        MapVisualisation(map);

        while (isPlaying)
        {
            heroX = movedX;
            heroY = movedY;
            Console.SetCursorPosition(heroX, heroY);
            Console.Write('@');
            HeroMovement(map, ref heroX, ref heroY, ref movedX, ref movedY);
        }

    }

    static void MapVisualisation(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            if (i == 0 || i == 14)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = '#';
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            else
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == 0 || j == 29)
                    {
                        map[i, j] = '#';
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        map[i, j] = '.';
                        Console.Write(map[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }

    static void HeroMovement(char[,] map, ref int x, ref int y, ref int dX, ref int dY)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[dY - 1, dX] == '#')
                    {
                        break;
                    }
                    else
                    {
                        dX = x;
                        dY = y - 1;
                        map[y, x] = ' ';
                        map[dY, dX] = ' ';
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(dX, dY);
                        Console.Write('@');
                        break;
                    }
                case ConsoleKey.DownArrow:
                    if (map[dY + 1, dX] == '#')
                    {
                        break;
                    }
                    else
                    {
                        dX = x;
                        dY = y + 1;
                        map[y, x] = ' ';
                        map[dY, dX] = ' ';
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(dX, dY);
                        Console.Write('@');
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    if (map[dY, dX - 1] == '#')
                    {
                        break;
                    }
                    else
                    {
                        dX = x - 1;
                        dY = y;
                        map[y, x] = ' ';
                        map[dY, dX] = ' ';
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(dX, dY);
                        Console.Write('@');
                        break;
                    }
                case ConsoleKey.RightArrow:
                    if (map[dY, dX + 1] == '#')
                    {
                        break;
                    }
                    else
                    {
                        dX = x + 1;
                        dY = y;
                        map[y, x] = ' ';
                        map[dY, dX] = ' ';
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(dX, dY);
                        Console.Write('@');
                        break;
                    }
            }
        }
    }

    static int AppleCount(char[,] map, ref int apllesCount)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == ' ')
                {
                    apllesCount++;
                }
            }
        }
        return apllesCount;
    }
}
