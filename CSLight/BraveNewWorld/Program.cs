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
            int enemyX, enemyY;
            int applesCollected = 0;
            bool isPlaying = true;

            Random random = new Random();
            InitializeMap(map, heroX, heroY, random);
            enemyX = random.Next(1, 10);
            enemyY = random.Next(1, 10);
            map[enemyY, enemyX] = 'W';
            int allApples = AppleSum(map);
            int enemyMoveDelay = 3000;
            int enemyMoveCounter = 0;

            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(heroX, heroY);
                Console.Write('@');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    int newHeroX = heroX, newHeroY = heroY;

                    ChangeDirection(key, ref newHeroY, ref newHeroX, ref isPlaying); //Вибір напрямку руху

                    if (IsCharacter(map, newHeroX, newHeroY, 'W'))
                    {
                        GameOver(map, "You lost!", ref isPlaying);
                    }
                    else if (IsMoveable(map, newHeroX, newHeroY))
                    {
                        if (map[newHeroY, newHeroX] == '.')
                        {
                            applesCollected++;
                        }

                        Movement(map, ref heroX, ref heroY, ref newHeroX, ref newHeroY); //Самий рух гравця
                    }

                    Console.SetCursorPosition(0, map.GetLength(0) + 1);
                    Console.WriteLine($"You have {applesCollected}/{allApples} apples.");

                    if (applesCollected == allApples)
                    {
                        GameOver(map, "You win!", ref isPlaying);
                    }
                }

                enemyMoveCounter++;
                if (enemyMoveCounter >= enemyMoveDelay)
                {
                    enemyMoveCounter = 0;
                    EnemyMovement(random, map, ref enemyX, ref enemyY, ref isPlaying); // Зміна для руху ворога
                }
            }
        }

        static void EnemyMovement(Random random, char[,] map, ref int enemyX, ref int enemyY, ref bool isPlaying)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write('W');
            map[enemyY, enemyX] = 'W';
            int newEnemyX = enemyX, newEnemyY = enemyY;
            int randomDirection = random.Next(1, 5);

            switch (randomDirection)
            {
                case 1: newEnemyX++; break;
                case 2: newEnemyX--; break;
                case 3: newEnemyY++; break;
                case 4: newEnemyY--; break;
            }

            if (IsMoveable(map, newEnemyX, newEnemyY))
            {
                char previousCell = map[newEnemyY, newEnemyX];

                if (IsCharacter(map, newEnemyX, newEnemyY, '@'))
                {
                    isPlaying = false;
                    Console.SetCursorPosition(0, map.GetLength(0) + 2);
                    Console.WriteLine("You lost!");
                    Console.ReadKey();
                }
                else if (IsCharacter(map, newEnemyX, newEnemyY, '.'))
                {
                    map[enemyY, enemyX] = ' ';
                    Console.SetCursorPosition(enemyX, enemyY);
                    Console.Write(' ');

                    map[newEnemyY, newEnemyX] = 'W';
                    Console.SetCursorPosition(newEnemyX, newEnemyY);
                    Console.Write('W');
                    enemyX = newEnemyX;
                    enemyY = newEnemyY;
                }
                else if (IsCharacter(map, newEnemyX, newEnemyY, ' '))
                {
                    if (previousCell != '.')
                    {
                        map[newEnemyY, newEnemyX] = previousCell; 
                        Console.SetCursorPosition(newEnemyX, newEnemyY);
                        Console.Write(previousCell);
                    }

                    map[enemyY, enemyX] = ' ';
                    Console.SetCursorPosition(enemyX, enemyY);
                    Console.Write(' ');
                    map[newEnemyY, newEnemyX] = 'W';
                    Console.SetCursorPosition(newEnemyX, newEnemyY);
                    Console.Write('W');
                    enemyX = newEnemyX;
                    enemyY = newEnemyY;
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

        static void ChangeDirection(ConsoleKeyInfo key, ref int newY, ref int newX, ref bool isPlaying)
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

        static bool IsCharacter(char[,] map, int x, int y, char symbol)
        {
            return map[y, x] == symbol;
        }

        static bool IsMoveable(char[,] map, int x, int y)
        {
            return map[y, x] != '#'; // Перевірка, чи клітинка прохідна
        }

        static void InitializeMap(char[,] map, int x, int y, Random random)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1 || j == 0 || j == map.GetLength(1) - 1)
                    {
                        map[i, j] = '#'; // Створення стін
                    }
                    else if (i == y && j == x)
                    {
                        map[i, j] = '@'; // Місце героя
                    }
                    else
                    {
                        map[i, j] = (random.Next(0, 10) < 2) ? '.' : ' '; // Генерація яблук на карті
                    }
                }
            }
        }

        static void GameOver(char[,] map, string text, ref bool isPlaying)
        {
            isPlaying = false;
            Console.SetCursorPosition(0, map.GetLength(0) + 2);
            Console.WriteLine(text);
            Console.ReadKey(); // Виведення повідомлення про кінець гри
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]); // Виведення карти
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
                        allApples++; // Підрахунок кількості яблук
                    }
                }
            }
            return allApples;
        }
    }
}
