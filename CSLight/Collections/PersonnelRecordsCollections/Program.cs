namespace PersonnelRecordsCollections;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> dossiers = new Dictionary<string, string>();
        bool isWorking = true;
        string menu = "Select menu item:\n1) Add a dossier.\n2) Display all dossiers.\n3) Delete a dossier.\n4) Exit.";

        Console.WriteLine("Welcome to the HR reporting application!");
        Menu(isWorking, dossiers, menu);
    }

    static void Menu(bool isWorking, Dictionary<string, string> dossiers, string text)
    {
        while (isWorking)
        {
            Console.WriteLine(text);
            int menuItem;
            if (int.TryParse(Console.ReadLine(), out menuItem) && menuItem > 0 && menuItem <= 4)
            {
                switch (menuItem)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Eter the first and last name of the employee:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the employee's position:");
                        string position = Console.ReadLine();
                        dossiers.Add(name, position);
                        break;
                    case 2:
                        Console.Clear();
                        if (dossiers.Count > 0)
                        {
                            Console.WriteLine("Dossiers List:");
                            foreach (var dossier in dossiers)
                            {
                                Console.Write($"{dossier.Key} - {dossier.Value}. ");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No dossier has been created yet.");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter the first and last name of the employee whose file you would like to delete:");
                        string employee = Console.ReadLine();
                        if (dossiers.ContainsKey(employee))
                        {
                            dossiers.Remove(employee);
                            Console.WriteLine($"Dossier for {employee} deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. There is no such employee.");
                        }
                        break;
                    case 4:
                        isWorking = false;
                        break;
                }
                Console.WriteLine("\nPress any button to continue.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter the number corresponding to the menu item.");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

}
