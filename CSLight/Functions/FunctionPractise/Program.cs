using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace FunctionPractise;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        bool isPlaying = true;

        Random random = new Random();

        int pacmanX, pacmanY;
        int pacmanDX = 0, pacmanDY = 1;
        bool isAlive = true;

        int ghostX, ghostY;
        int ghostDX = 0, ghostDY = -1;

        int allDots = 0;
        int collectDots = 0;

        char[,] map = Readmap("map1", out pacmanX, out pacmanY, ref allDots, out ghostX, out ghostY);

        DrawMap(map);

        while (isPlaying)
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"You have {collectDots}/{allDots}");

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangeDirection(key, ref pacmanDX, ref pacmanDY);

            }
            if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
            {
                CollectDots(map, pacmanX, pacmanY, ref collectDots);
                
                Move(map, '@', ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
            }

            if (map[ghostX + ghostDX, ghostY + ghostDY] != '#')
            {
                Move(map, 'W', ref ghostX, ref ghostY, ghostDX, ghostDY);
            }
            else
            {
                ChangeDirection(random, ref ghostDX, ref ghostDY);
            }

            System.Threading.Thread.Sleep(200);

            if(ghostX == pacmanX && ghostY == pacmanY)
            {
                isAlive = false;
            }

            if (collectDots == allDots || isAlive == false)
            {
                isPlaying = false;
            }
        }

        Console.SetCursorPosition(0, 26);
        if (collectDots == allDots)
        {
            Console.WriteLine("You won!");
            Console.ReadLine();
        }
        else if (isAlive == false)
        {
            Console.WriteLine("You've been eaten");
            Console.ReadLine();
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

    static void Move(char[,] map, char symbol, ref int X, ref int Y, int DX, int DY)
    {
        Console.SetCursorPosition(Y, X);
        Console.Write(map[X,Y]);

        X += DX;
        Y += DY;

        Console.SetCursorPosition(Y, X);
        Console.Write(symbol);
    }

    static void CollectDots(char[,] map, int pacmanX, int pacmanY, ref int collectDots)
    {
        if (map[pacmanX, pacmanY] == '.')
        {
            collectDots++;
            map[pacmanX, pacmanY] = ' ';
        }
    }

    static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                DX = -1; DY = 0;
                break;
            case ConsoleKey.DownArrow:
                DX = 1; DY = 0;
                break;
            case ConsoleKey.LeftArrow:
                DX = 0; DY = -1;
                break;
            case ConsoleKey.RightArrow:
                DX = 0; DY = 1;
                break;
        }
    }

    static void ChangeDirection(Random random, ref int DX, ref int DY)
    {
        int ghostDir = random.Next(1, 5);
        switch (ghostDir)
        {
            case 1:
                DX = -1; DY = 0;
                break;
            case 2:
                DX = 1; DY = 0;
                break;
            case 3:
                DX = 0; DY = -1;
                break;
            case 4:
                DX = 0; DY = 1;
                break;
        }
    }

    static char[,] Readmap(string manName, out int pacmanX, out int pacmanY, ref int allDots, out int ghostX, out int ghostY)
    {
        pacmanX = 0;
        pacmanY = 0;
        ghostX = 0;
        ghostY = 0;

        string[] newFile = File.ReadAllLines($"Maps/{manName}.txt");
        char[,] map = new char[newFile.Length, newFile[0].Length];

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = newFile[i][j];

                if (map[i, j] == '@')
                {
                    pacmanX = i;
                    pacmanY = j;
                    map[i, j] = '.';
                }
                else if (map[i, j] == 'W')
                {
                    ghostX = i;
                    ghostY = j;
                    map[i, j] = '.';
                }
                else if (map[i, j] == ' ')
                {
                    map[i, j] = '.';
                    allDots++;
                }
            }
        }

        return map;
    }
}
