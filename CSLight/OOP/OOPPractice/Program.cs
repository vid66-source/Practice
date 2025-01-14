using System.Formats.Asn1;

namespace OOPPractice;
qqqq
class Program
{
    static void Main(string[] args)
    {
        Table[] tables = { new Table(1, 5), new Table(2, 10), new Table(3, 20) };

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine("Cafe administrating.\n");

            Console.SetCursorPosition(0, 20);
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i].ShowInfo();
            }

            Console.WriteLine("\nEnter table number");
            int userTable = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Enter places number");
            int userPlce = Convert.ToInt32(Console.ReadLine());

            bool isReserve = tables[userTable].Reserve(userPlce);
            if (isReserve)
            {
                Console.WriteLine("Places were reserve.");
            }
            else
            {
                Console.WriteLine("Wrong input.");
            }

            Console.ReadKey();
            Console.Clear();
        }

    }
}

class Table
{
    private int _number;
    private int _maxPlace;
    private int _freePlace;

    public Table(int number, int maxPlace)
    {
        _number = number;
        _maxPlace = maxPlace;
        _freePlace = maxPlace;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Table - {_number}. Free places - {_freePlace}/{_maxPlace}");
    }

public bool Reserve(int palce)
{
    bool isReserve;

    isReserve = _freePlace >= palce;

    if (isReserve)
    {
        _freePlace -= palce;
        return isReserve;
    }
    else
    {
        return isReserve;
    }
}
}
