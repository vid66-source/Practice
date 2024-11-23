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

            // Генерація карти
            InitializeMap(map);
            DrawMap(map);

            // Головний ігровий цикл
            while (isPlaying)
            {
                Console.SetCursorPosition(heroX, heroY);
                Console.Write('@');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    int newHeroX = heroX, newHeroY = heroY;

                    // Обробка руху
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow: newHeroY--; break;
                        case ConsoleKey.DownArrow: newHeroY++; break;
                        case ConsoleKey.LeftArrow: newHeroX--; break;
                        case ConsoleKey.RightArrow: newHeroX++; break;
                        case ConsoleKey.Escape: isPlaying = false; break;
                    }

                    // Перевірка і взаємодія з картою
                    if (IsWalkable(map, newHeroX, newHeroY))
                    {
                        if (map[newHeroY, newHeroX] == '.')
                        {
                            applesCollected++;
                        }

                        // Оновлення карти та позиції героя
                        Console.SetCursorPosition(heroX, heroY);
                        Console.Write(' ');
                        map[heroY, heroX] = ' ';
                        heroX = newHeroX;
                        heroY = newHeroY;
                        map[heroY, heroX] = '@';
                    }

                    // Вивід кількості яблук
                    Console.SetCursorPosition(0, map.GetLength(0) + 1);
                    Console.WriteLine($"You have {applesCollected} apples.");
                }
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
                        map[i, j] = '#'; // Стіна
                    }
                    else
                    {
                        map[i, j] = (new Random().Next(0, 10) < 2) ? '.' : ' '; // 20% шанс на яблуко
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
            return map[y, x] != '#'; // Можна ходити, якщо це не стіна
        }
    }
}
