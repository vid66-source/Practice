using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace OOPPractice4;

class Program
{
    static void Main(string[] args)
    {
        ComputerClub computerClub = new ComputerClub(8);
        computerClub.Work();
    }

    class ComputerClub
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Schoolboy> _schoolboys = new Queue<Schoolboy>();

        public ComputerClub(int computerCount)
        {
            Random rand = new Random();

            for (int i = 0; i < computerCount; i++)
            {
                _computers.Add(new Computer(rand.Next(5, 15)));
            }

            CreateNewSchoolboy(25);

        }

        private void CreateNewSchoolboy(int count)
        {
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                _schoolboys.Enqueue(new Schoolboy(rand.Next(100, 250), rand));
            }
        }

        public void Work()
        {
            while (_schoolboys.Count > 0)
            {
                Console.WriteLine($"There are {_money} hryvnias in the computer club account. Waiting for a new custumer.");

                Schoolboy schoolboy = _schoolboys.Dequeue();
                Console.WriteLine($"There is schoolboy in queue and he wants to buy {schoolboy.DesiredMinutes} minutes");
                Console.WriteLine("\nFree places list");
                ShowAllComputers();

                Console.Write("\nYou want to offer the visitor computer number ");
                int computerNumber = Convert.ToInt32(Console.ReadLine());

                if (computerNumber >= 0 && computerNumber < _computers.Count)
                {
                    if(_computers[computerNumber].IsBusy)
                    {
                        Console.WriteLine("The seat you offered the visitor is taken. The visitor has left.");
                    }
                    else
                    {
                        if(schoolboy.CheckSolvency(_computers[computerNumber]))
                        {
                            Console.WriteLine("The visitor paid the required amount and borrowed the computer.");
                            _money += schoolboy.ToPay();

                            _computers[computerNumber].TakeThePlace(schoolboy);
                        }
                        else
                        {
                            Console.WriteLine("Visitor has left because he didn't have enough money.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You yourself don't understand what place to offer, the client has left.");
                }

                Console.WriteLine("To interact with the next client - press any key.");
                Console.ReadKey();
                Console.Clear();
                SkipMinute();
            }
        }

        public void SkipMinute()
        {
            foreach (var computer in _computers)
            {
                computer.SkipMinute();
            }
        }

        private void ShowAllComputers()
        {
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write($"{i} - ");
                _computers[i].ShowInfo();
            }
        }
    }

    class Computer
    {
        private Schoolboy _schoolboy;
        private int _minutesLeft;

        public int PriceForMinutes { get; private set; }
        public bool IsBusy
        {
            get { return _minutesLeft > 0; }
        }

        public Computer(int priceForMinutes)
        {
            PriceForMinutes = priceForMinutes;
        }

        public void TakeThePlace(Schoolboy schoolboy)
        {
            _schoolboy = schoolboy;
            _minutesLeft = schoolboy.DesiredMinutes;
        }

        public void FreeThePlace()
        {
            _schoolboy = null;
        }

        public void SkipMinute()
        {
            _minutesLeft--;
        }

        public void ShowInfo()
        {
            if (IsBusy)
                Console.WriteLine($"Place is reserved. Minutes left - {_minutesLeft}");
            else
                Console.WriteLine($"Place is free. Price per minute - {PriceForMinutes}.");
        }
    }

    class Schoolboy
    {
        private int _money;
        private int _moneyToPay;

        public int DesiredMinutes { get; private set; }

        public Schoolboy(int money, Random rand)
        {
            _money = money;
            DesiredMinutes = rand.Next(10, 30);
        }


        public bool CheckSolvency(Computer computer)
        {
            _moneyToPay = computer.PriceForMinutes * DesiredMinutes;
            if(_money >= _moneyToPay)
            {
                return true;
            }
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public int ToPay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}
