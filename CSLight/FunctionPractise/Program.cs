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
        char[,] map = Readmap("map1");

        int packmanX, packmanY;

        DrawMap(map);
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

    static char[,] Readmap(string manName)
    {
        string[] newFile = File.ReadAllLines($"Maps/{manName}.txt");
        char[,] map = new char[newFile.Length, newFile[0].Length];

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i,j] = newFile[i][j];
            }
        }
        return map;
    }
}
