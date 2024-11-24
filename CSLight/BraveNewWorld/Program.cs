using System;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map = new char[15, 30];
            int heroX = 10, heroY = 10;
            int applesCollected = 0;
            bool isPlaying = true;


            InitializeMap(map);
            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(heroX, heroY);
                Console.Write('@');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    int newHeroX = heroX, newHeroY = heroY;

                    ChangeDiraction(key, ref newHeroY, ref newHeroX, isPlaying);

                    if (IsWalkable(map, newHeroX, newHeroY))
                    {
                        if (map[newHeroY, newHeroX] == '.')
                        {
                            applesCollected++;
                        }

                        MoveMent(map, ref heroX, ref heroY, ref newHeroX, ref newHeroY);
                    }

                    Console.SetCursorPosition(0, map.GetLength(0) + 1);
                    Console.WriteLine($"You have {applesCollected} apples.");
                }

            }
        }

        static void MoveMent(char[,] map, ref int x, ref int y, ref int newX, ref int newY)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            map[y, x] = ' ';
            x = newX;
            y = newY;
            map[y, x] = '@';
        }


        static void ChangeDiraction(ConsoleKeyInfo key, ref int newY, ref int newX, bool isPlaying)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.Escape: isPlaying = false; break;
            }
        }


        static void InitializeMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1 || j == 0 || j == map.GetLength(1) - 1)
                    {
                        map[i, j] = '#';
                    }
                    else
                    {
                        map[i, j] = (new Random().Next(0, 10) < 2) ? '.' : ' ';
                    }
                }
            }
        }

        static void DrawMap(char[,] map)
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

        static bool IsWalkable(char[,] map, int x, int y)
        {
            return map[y, x] != '#';
        }
    }
}
