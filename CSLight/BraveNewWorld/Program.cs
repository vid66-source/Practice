using System;
using System.Runtime.CompilerServices;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map = new char[15, 30];
            int heroX = 10, heroY = 10;
            int enemyX = 1, enemyY = 1;
            int applesCollected = 0;
            int allApples;
            bool isPlaying = true;

            InitializeMap(map, heroX, heroY);
            map[enemyX, enemyY] = 'W';
            allApples = AppleSum(map);
            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(heroX, heroY);
                Console.Write('@');
                Console.SetCursorPosition(enemyX, enemyY);
                Console.Write('W');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    int newHeroX = heroX, newHeroY = heroY;

                    ChangeDiraction(key, ref newHeroY, ref newHeroX, isPlaying);

                    if (IsEnemy(map, newHeroX, newHeroY))
                    {
                        string text = "You lost!";
                        EndOfTheGame(map, text, ref isPlaying);
                    }
                    else if (IsWalkable(map, newHeroX, newHeroY))
                    {
                        if (map[newHeroY, newHeroX] == '.')
                        {
                            applesCollected++;
                        }

                        Movement(map, ref heroX, ref heroY, ref newHeroX, ref newHeroY);
                    }

                    Console.SetCursorPosition(0, map.GetLength(0) + 1);
                    Console.WriteLine($"You have {applesCollected} apples.");
                }
                else if (applesCollected == allApples)
                {
                    string text = "You win!";
                    EndOfTheGame(map, text, ref isPlaying);
                }
            }
        }

        static void Movement(char[,] map, ref int x, ref int y, ref int newX, ref int newY)
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

        static bool IsWalkable(char[,] map, int x, int y)
        {
            return map[y, x] != '#';
        }

        static bool IsEnemy(char[,] map, int x, int y)
        {
            return map[y, x] == 'W';
        }



        static void InitializeMap(char[,] map, int x, int y)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1 || j == 0 || j == map.GetLength(1) - 1)
                    {
                        map[i, j] = '#';
                    }
                    else if (i == y && j == x)
                    {
                        map[i, j] = '@';
                    }
                    else
                    {
                        map[i, j] = (new Random().Next(0, 10) < 2) ? '.' : ' ';
                    }
                }
            }
        }

        static void EndOfTheGame(char[,] map, string text, ref bool isPlaying)
        {
            isPlaying = false;
            Console.SetCursorPosition(0, map.GetLength(0) + 2);
            Console.WriteLine(text);
            Console.ReadKey();
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

        static int AppleSum(char[,] map)
        {
            int allApples = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '.')
                    {
                        allApples++;
                    }
                }
            }
            return allApples;
        }
    }
}
