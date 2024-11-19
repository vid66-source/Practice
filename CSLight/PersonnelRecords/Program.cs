namespace PersonnelRecords;

class Program
{
    static void Main(string[] args)
    {

        string[] fullNames = new string[0];
        string[] workPositions = new string[0];
        string newName;
        string newSurname;
        string newPosition;
        string surname;
        int dossierNum;

        bool isRunning = true;
        string menu = """
            Welcome to the Dossier Management System!

            Menu:
            1) Add a dossier
            2) Display all dossiers (in one line with a serial number, full name, and position separated by a dash)
            3) Delete a dossier
            4) Search by last name
            5) Exit

            Please select an option:
            """;



        while (isRunning)
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine(menu);

            switch (Console.ReadLine())
            {
                case "1":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Enter name:");
                    newName = Console.ReadLine();
                    Console.WriteLine("Enter surname:");
                    newSurname = Console.ReadLine();
                    AddNewName(fullNames, newName, newSurname, out fullNames);
                    Console.WriteLine("Enter position:");
                    newPosition = Console.ReadLine();
                    AddNewPosition(workPositions, newPosition, out workPositions);
                    Console.WriteLine("\nPress Enter to choose another option");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    if (fullNames.Length == 0 && workPositions.Length == 0)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("There are no dossiers.");
                        Console.WriteLine("\n\nPress Enter to choose another option");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Dossiers list:");
                        ShowAllDossiers(fullNames, workPositions);
                        Console.WriteLine("\n\nPress Enter to choose another option");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case "3":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Enter dossier number.");
                    dossierNum = Convert.ToInt32(Console.ReadLine());
                    if (fullNames.Length > 0 && workPositions.Length > 0)
                    {
                        DeleteDossier(dossierNum, fullNames, workPositions, out fullNames, out workPositions);
                    }
                    else
                    {
                        Console.WriteLine("There is no dossiers to delete.");
                    }
                    Console.WriteLine("\nPress Enter to choose another option");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Please enter employee surname");
                    surname = Console.ReadLine();
                    FindDossier(fullNames, workPositions, surname);
                    Console.WriteLine("\nPress Enter to choose another option");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    isRunning = false;
                    break;
            }
        }

        static string[] AddNewName(string[] names, string newFullName, string newSurname, out string[] newFullNamesArray)
        {
            string[] fullNamesTemp = new string[names.Length + 1];

            for (int i = 0; i < names.Length; i++)
            {
                fullNamesTemp[i] = names[i];
            }

            fullNamesTemp[fullNamesTemp.Length - 1] = $"{newFullName} {newSurname}";

            newFullNamesArray = fullNamesTemp;

            return newFullNamesArray;
        }

        static string[] AddNewPosition(string[] positions, string newPosition, out string[] newWorkPositionArray)
        {
            string[] workPositionsTemp = new string[positions.Length + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                workPositionsTemp[i] = positions[i];
            }

            workPositionsTemp[workPositionsTemp.Length - 1] = newPosition;

            newWorkPositionArray = workPositionsTemp;

            return newWorkPositionArray;
        }

        static void ShowAllDossiers(string[] fullNames, string[] workPositions)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write($"{i + 1}. {fullNames[i]} - {workPositions[i]} ");
            }
        }

        static void DeleteDossier(int dossierNum, string[] names, string[] positions, out string[] newfullNamesArray, out string[] newWorkPositionsArray)
        {
            string[] fullNamesTemp = new string[names.Length - 1];

            if (dossierNum == names.Length)
            {
                for (int i = 0; i < fullNamesTemp.Length; i++)
                {
                    fullNamesTemp[i] = names[i];
                }
            }
            else if (dossierNum < names.Length && dossierNum > 0)
            {
                for (int i = 0; i < fullNamesTemp.Length; i++)
                {
                    if ((dossierNum - 1) == i)
                    {
                        fullNamesTemp[i] = names[i + 1];
                    }
                    else
                    {
                        fullNamesTemp[i] = names[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong dossier number.");
            }

            newfullNamesArray = fullNamesTemp;

            string[] workPositionsTemp = new string[positions.Length - 1];

            if (dossierNum == positions.Length)
            {
                for (int i = 0; i < workPositionsTemp.Length; i++)
                {
                    workPositionsTemp[i] = positions[i];
                }
            }
            else if (dossierNum < names.Length && dossierNum > 0)
            {
                for (int i = 0; i < workPositionsTemp.Length; i++)
                {
                    if ((dossierNum - 1) == i)
                    {
                        workPositionsTemp[i] = positions[i + 1];
                    }
                    else
                    {
                        workPositionsTemp[i] = positions[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong dossier number.");
            }

            newWorkPositionsArray = workPositionsTemp;
        }

        static void FindDossier(string[] names, string[] positions, string surname)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().Contains(surname.ToLower()))
                {
                    Console.WriteLine($"{i + 1}. {names[i]} - {positions[i]}.");
                }
                else
                {
                    Console.WriteLine("There is no such employee.");
                }
            }
        }
    }
}
