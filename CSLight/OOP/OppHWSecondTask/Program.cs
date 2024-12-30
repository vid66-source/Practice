namespace OppHWSecondTask;

class Program
{
    static void Main(string[] args)
    {
        Administrator administrator= new Administrator();
    }
}

class Administrator
{
    public bool isWorking = true;
    List<Player> players;

    public Administrator()
    {
        players = new List<Player>();
    }

    public void AddPlayer(List<Player> players)
    {
        Console.WriteLine("Please enter player Nickname:");
        string playerNick = Console.ReadLine();
        Console.WriteLine("Please enter player lvl:");
        string userInput = Console.ReadLine();
        bool isValidnumber = int.TryParse(userInput, out int playerLvl);
        if (isValidnumber && playerLvl > 0 && playerLvl <= 100)
        {
            Player newPlayer = new Player(playerNick, playerLvl);
            players.Add(newPlayer);
            Console.WriteLine("Player added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid player level. Please enter a valid player level; the number must be greater than zero and less than 100.");
        }
    }

    public void DeleteAPlayer(List<Player> players)
    {
        Console.WriteLine("Please enter the player ID whom you want to delete.");
        string userInput = Console.ReadLine();
        bool isValidnumber = int.TryParse(userInput, out int chosenPlayerID);
        if (isValidnumber)
        {
            for (int i = players.Count - 1; i >= 0; i--)
            {
                if (players[i].PlayerID == chosenPlayerID)
                {
                    players.RemoveAt(i);
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input, please try again.");
        }
    }

    public void BanStatus(List<Player> players)
    {
        if (players.Count > 0)
        {
            var minMaxIDValue = CheckMaxMinID(players);
            Console.WriteLine("Please select the player by ID whom you want to ban/unban or press the ESC key to return to the main menu.");
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\nReturning to the main menu...");
                return;
            }

            bool isValidnumber = false;
            int chosenPlayerID = 0;

            while (!isValidnumber)
            {
                string userInput = Console.ReadLine();
                isValidnumber = int.TryParse(userInput, out chosenPlayerID);
                if (!isValidnumber || minMaxIDValue.MaxPlayerID < chosenPlayerID || minMaxIDValue.MinPlayerID < chosenPlayerID)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }

            for (int i = players.Count - 1; i >= 0; i--)
            {
                if (players[i].PlayerID == chosenPlayerID)
                {
                    if (players[i].IsBanned == false)
                    {
                        players[i].UpdateBanStatus();
                        Console.WriteLine("Player was banned");
                    }
                    if (players[i].IsBanned == true)
                    {
                        players[i].UpdateBanStatus();
                        Console.WriteLine("Player was unbanned");
                    }
                }
            }

        }
        else
        {
            Console.WriteLine("Список гравців порожній.");
        }
    }

    private (int MaxPlayerID, int MinPlayerID) CheckMaxMinID(List<Player> players)
    {
        int PlayerIDMaxValue = players[0].PlayerID;
        int PlayerIDMinValue = players[0].PlayerID;
        for (int i = 1; i < players.Count; i++)
        {
            if (players[i].PlayerID > PlayerIDMaxValue)
            {
                PlayerIDMaxValue = players[i].PlayerID;
            }
            else if
            (players[i].PlayerID < PlayerIDMinValue)
            {
                PlayerIDMinValue = players[i].PlayerID;
            }
        }
        return (PlayerIDMaxValue, PlayerIDMinValue);
    }
}

class Player
{
    private static int counter = 0;
    public int PlayerID { get; private set; }
    public string PlayerNick { get; private set; }
    public int PlayerLvl { get; private set; }
    public bool IsBanned { get; private set; }

    public Player(string playerNick, int playerLvl)
    {
        PlayerNick = playerNick;
        PlayerLvl = playerLvl;
        PlayerID = counter++;
        IsBanned = false;
    }

    public void UpdateBanStatus()
    {
        if (IsBanned == true)
        {
            IsBanned = false;
        }
        else
        {
            IsBanned = true;
        }
    }

    public void PlayerInfo()
    {
        if (IsBanned == true)
            Console.WriteLine($"Player ID: {PlayerID}, player name: {PlayerNick}, player level: {PlayerLvl}, player is banned");
        else
            Console.WriteLine($"Player ID: {PlayerID}, player name: {PlayerNick}, player level: {PlayerLvl}, player is not banned");
    }
}