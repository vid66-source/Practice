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
                    fullNames = AddNewElement(fullNames, $"{newName} {newSurname}");
                    Console.WriteLine("Enter position:");
                    newPosition = Console.ReadLine();
                    workPositions = AddNewElement(workPositions, newPosition);
                    WaitingUserInput();
                    break;
                case "2":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Dossiers list:");
                    ShowAllDossiers(fullNames, workPositions);
                    WaitingUserInput();
                    break;
                case "3":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Enter dossier number.");
                    dossierNum = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (dossierNum >= 0 && dossierNum < fullNames.Length && dossierNum < workPositions.Length)
                    {
                        fullNames = DeleteElement(dossierNum, fullNames);
                        workPositions = DeleteElement(dossierNum, workPositions);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please enter a valid dossier number.");
                    }
                    WaitingUserInput();
                    break;
                case "4":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Please enter employee surname");
                    surname = Console.ReadLine();
                    FindDossier(fullNames, workPositions, surname);
                    WaitingUserInput();
                    break;
                case "5":
                    isRunning = false;
                    break;
            }
        }

        static string[] AddNewElement(string[] array, string newElement)
        {
            string[] arrayTemp = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                arrayTemp[i] = array[i];
            }

            arrayTemp[arrayTemp.Length - 1] = newElement;

            return arrayTemp;
        }

        static void ShowAllDossiers(string[] fullNames, string[] workPositions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("There are no dossiers.");
                return;
            }

            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write($"{i + 1}. {fullNames[i]} - {workPositions[i]} ");
            }
        }

        static string[] DeleteElement(int index, string[] array)
        {
            string[] arrayTemp = new string[array.Length - 1];
            
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (i != index)
                {
                    arrayTemp[j++] = array[i];
                }
            }

            return arrayTemp;
        }

        static void FindDossier(string[] names, string[] positions, string surname)
        {
            bool found = false;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().Contains(surname.ToLower()))
                {
                    Console.WriteLine($"{i + 1}. {names[i]} - {positions[i]}.");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("There is no such employee.");
            }
        }

        static void WaitingUserInput()
        {
            Console.WriteLine("\nPress Enter to choose another option");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
