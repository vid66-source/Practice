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
            int enemyX, enemyY;
            int applesCollected = 0;
            bool isPlaying = true;

            Random random = new Random();
            InitializeMap(map, heroX, heroY, random);
            int randomNumX = random.Next(1, 10);
            int randomNumY = random.Next(1, 10);
            enemyX = randomNumX;
            enemyY = randomNumY;
            map[enemyY, enemyX] = 'W';
            int allApples = AppleSum(map);
            int enemyMoveDelay = 3000;
            int enemyMoveCounter = 0;
            bool wasAnApple = false;
            bool wasASpace = true;

            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(heroX, heroY);
                Console.Write('@');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    int newHeroX = heroX, newHeroY = heroY;

                    ChangeDiraction(key, ref newHeroY, ref newHeroX, ref isPlaying);

                    if (IsCharacter(map, newHeroX, newHeroY, 'W'))
                    {
                        string text = "You lost!";
                        GameOver(map, text, ref isPlaying);
                    }
                    else if (IsMoveable(map, newHeroX, newHeroY))
                    {
                        if (map[newHeroY, newHeroX] == '.')
                        {
                            applesCollected++;
                        }

                        Movement(map, ref heroX, ref heroY, ref newHeroX, ref newHeroY);
                    }

                    Console.SetCursorPosition(0, map.GetLength(0) + 1);
                    Console.WriteLine($"You have {applesCollected}/{allApples} apples.");

                    if (applesCollected == allApples)
                    {
                        string text = "You win!";
                        GameOver(map, text, ref isPlaying);
                    }
                }

                enemyMoveCounter++;
                if (enemyMoveCounter >= enemyMoveDelay)
                {
                    enemyMoveCounter = 0;
                    EnemyMovement(random, map, ref enemyX, ref enemyY, ref isPlaying, ref wasAnApple, ref wasASpace);
                }
            }
        }

        static void EnemyMovement(Random random, char[,] map, ref int enemyX, ref int enemyY, ref bool isPlaying, ref bool wasAnApple, ref bool wasASpace)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write('W');
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
                if (IsCharacter(map, newEnemyX, newEnemyY, '.') && wasAnApple == true)
                {
                    EnemyMovementElement(map, ref enemyX, ref enemyY, ref newEnemyX, ref newEnemyY, '.');
                    wasAnApple = true;
                    wasASpace = false;
                }
                else if (IsCharacter(map, newEnemyX, newEnemyY, '.') && wasASpace == true)
                {
                    EnemyMovementElement(map, ref enemyX, ref enemyY, ref newEnemyX, ref newEnemyY, ' ');
                    wasAnApple = true;
                    wasASpace = false;
                }
                else if (IsCharacter(map, newEnemyX, newEnemyY, ' ') && wasAnApple == true)
                {
                    EnemyMovementElement(map, ref enemyX, ref enemyY, ref newEnemyX, ref newEnemyY, '.');
                    wasAnApple = false;
                    wasASpace = true;
                }
                else if (IsCharacter(map, newEnemyX, newEnemyY, ' ') && wasASpace == true)
                {
                    EnemyMovementElement(map, ref enemyX, ref enemyY, ref newEnemyX, ref newEnemyY, ' ');
                    wasAnApple = false;
                    wasASpace = true;
                }
                else if (IsCharacter(map, newEnemyX, newEnemyY, '@'))
                {
                    isPlaying = false;
                    Console.SetCursorPosition(0, map.GetLength(0) + 2);
                    Console.WriteLine("You lost!");
                    Console.ReadKey();
                }
            }
        }

        static void EnemyMovementElement(char[,] map, ref int enemyX, ref int enemyY, ref int newEnemyX, ref int newEnemyY, char symbol)
        {
            map[enemyY, enemyX] = symbol;
            Console.SetCursorPosition(enemyX, enemyY);
            Console.WriteLine(symbol);
            map[newEnemyY, newEnemyX] = 'W';
            Console.SetCursorPosition(newEnemyX, newEnemyY);
            Console.WriteLine('W');
            enemyX = newEnemyX; enemyY = newEnemyY;
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


        static void ChangeDiraction(ConsoleKeyInfo key, ref int newY, ref int newX, ref bool isPlaying)
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
            return map[y, x] != '#';
        }


        static void InitializeMap(char[,] map, int x, int y, Random random)
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
                        map[i, j] = (random.Next(0, 10) < 2) ? '.' : ' ';
                    }
                }
            }
        }

        static void GameOver(char[,] map, string text, ref bool isPlaying)
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
