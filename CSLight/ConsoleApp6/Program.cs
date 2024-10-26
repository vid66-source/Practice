using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp6;

class Program
{
    static void Main(string[] args)
    {
        string secretInfo = @"

        ---

        CODE NAME: ""GUARDIAN""
        CLASSIFICATION LEVEL: STRATEGIC THREAT ASSESSMENT
        DOSSIER NUMBER: FS-2218-ALPHA

        RECIPIENT: MAIN OPERATIONS UNIT (HQ-7)
        TRANSMISSION TIME: 14:32 GMT
        ACCESS CODE: SIGMA-7-ZULU

        ---

        REPORT FROM TASK FORCE ""TANGERINE"":

        Following the successful interception of a package from agent ""Striker,"" it has been confirmed that operation ""Eclipse"" is in its penultimate phase.
        All identified markers point to the activation of ""Object-Charlie"" within 72 hours.

        The target is located in a high-risk zone. Potential links to the ""Black Gate"" initiative were confirmed through secure communications intercepted at 47° east longitude.
        Data access will only be available after the activation of protocol ""Omega-13.""

        PRIORITY: OMEGA
        All assets are to be redirected to ""North-5"" and ""Delta-2"" locations.
        Field agents are ordered to establish direct contact with the target pending approval from central command.

        Activation code: Z45-RED-SILENT. Time until final report: 24 hours.

        END OF TRANSMISSION
        ";

        string password = "Phantom4g3nt!99";
        string userInput = "";
        int tryCount = 0;
        ConsoleColor originalColor = Console.ForegroundColor;

        Console.WriteLine("To access the classified information, please enter your password below:");

        while ( tryCount < 3 || userInput == password)
        {
            userInput = Console.ReadLine();
            if (userInput != password)
            {
                Console.WriteLine("Access Denied:\nThe password you entered is incorrect. Please try again.");
                tryCount ++;
            }
            else if (userInput == password)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(secretInfo);
                Console.ForegroundColor = originalColor;
                break;
            }
        }
    }
}
