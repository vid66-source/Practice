using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ConsoleApp5;

public class Cycle
{
    public void PrintNumbers() // Метод для виведення чисел
    {
        for (int i = 7; i <= 98; i += 7) // Правильний запис циклу for
        {
            Console.WriteLine(i); // Виведення значення i
        }
    }
}

