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

        int pacmanX, pacmanY;
        int pacmanDX = 0, pacmanDY = 1;

        char[,] map = Readmap("map1", out pacmanX, out pacmanY);

        DrawMap(map);

        while (isPlaying)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangeDirection(key, ref pacmanDX, ref pacmanDY);

            }
            if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
            {
                Move(ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
            }
            System.Threading.Thread.Sleep(150);
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

    static void Move(ref int X, ref int Y, int DX, int DY)
    {
        Console.SetCursorPosition(Y, X);
        Console.Write(' ');

        X += DX;
        Y += DY;

        Console.SetCursorPosition(Y, X);
        Console.Write('@');
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

    static char[,] Readmap(string manName, out int pacmanX, out int pacmanY)
    {
        pacmanX = 0;
        pacmanY = 0;

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
                }
                else
                {
                    
                }
            }
        }

        return map;
    }
}
