﻿namespace PersonnelRecords;

class Program
{
    static void Main(string[] args)
    {

        string[] fullNames = new string[0];
        string[] workPositions = new string[0];
        string newName;
        string newSurname;
        string newPosition;

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
                    Console.Clear();
                    break;
                case "2":
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Dossiers list:");
                    ShowAllDossiers(fullNames, workPositions);
                    break;
                case "3":

                    break;
                case "4":
                    break;
                case "5":
                    isRunning = false;
                    break;
            }
        }

        static string[] AddNewName(string[] fullNames, string newFullName, string newSurname, out string[] newFullNamesArray)
        {
            string[] fullNamesTemp = new string[fullNames.Length + 1];

            for (int i = 0; i < fullNames.Length; i++)
            {
                fullNamesTemp[i] = fullNames[i];
            }

            fullNamesTemp[fullNamesTemp.Length - 1] = $"{newFullName} {newSurname}";

            newFullNamesArray = fullNamesTemp;

            return newFullNamesArray;
        }

        static string[] AddNewPosition(string[] workPositions, string newPosition, out string[] newWorkPositionArray)
        {
            string[] workPositionsTemp = new string[workPositions.Length + 1];

            for (int i = 0; i < workPositions.Length; i++)
            {
                workPositionsTemp[i] = workPositions[i];
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

        static string[] DeleteDossier(int dossierNum, string[] fullNames, string[] workPositions, out newfullNamesArray, out newWorkPositionsArray)
        {
            string[] fullNamesTemp = new string[fullNames.Length - 1];

            for (int i = 0; i < fullNames.Length; i++)
            {
                fullNamesTemp[i] = fullNames[i];
                if (i == dossierNum--)
                {
                    break;
                }
            }
            
            newfullNamesArray = fullNamesTemp;

            return newfullNamesArray;
        }
    }
}
