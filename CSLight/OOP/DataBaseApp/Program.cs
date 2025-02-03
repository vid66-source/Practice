namespace DataBaseApp;

class Program
{
    static void Main(string[] args)
    {
        Administrator administrator = new Administrator();
        while (administrator.isWorking)
        {
            Console.WriteLine("Administrator menu:\n1. Add a new player. \n2. Ban or unban a player with using his ID.\n3. Delete a player with using his ID.\n4. Show all players info.\n5. Exit.");
            string administratorChoise = Console.ReadLine();
            switch (administratorChoise)
            {
                case "1":
                    administrator.AddPlayer();
                    break;
                case "2":
                    administrator.ChangeBanStatus();
                    break;
                case "3":
                    administrator.DeleteAPlayer();
                    break;
                case "4":
                    administrator.ShowAllPlayersInfo();
                    break;
                case "5":
                    administrator.isWorking = false;
                    break;
                default:
                    Console.WriteLine("Incorrect menu item.");
                    break;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

class Administrator
{
    public bool isWorking { get; set; }
    List<Player> players;
    private PlayerIDRange playerIDRange;

    private struct PlayerIDRange
    {
        public int MaxPlayerID { get; private set; }
        public int MinPlayerID { get; private set; }

        public PlayerIDRange(int maxPlayerID, int minPlayerID)
        {
            MaxPlayerID = maxPlayerID;
            MinPlayerID = minPlayerID;
        }
    }


    public Administrator()
    {
        isWorking = true;
        players = new List<Player>();
        playerIDRange = new PlayerIDRange(0, 0);
    }

    public void AddPlayer()
    {
        Console.WriteLine("Please enter a new player nickname or press the ESC key to return to the main menu:");
        if (CheckForEscKey()) return;

        string userNickNameInput;
        while (true)
        {
            userNickNameInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userNickNameInput))
                break;
            Console.WriteLine("Nickname cannot be empty. Please try again.");
        }

        Console.WriteLine("Please enter a new player level(level range from 1 to 100):");
        int playerLvl = InputNumCheck(100, 1, "Invalid player level.");
        Player newPlayer = new Player(userNickNameInput, playerLvl);
        players.Add(newPlayer);
        Console.WriteLine("Player added successfully.");
        UpdatePlayerIDRange();
    }

    public void DeleteAPlayer()
    {
        if (players.Count > 0)
        {
            Console.WriteLine("Please enter the player ID whom you want to delete or press the ESC key to return to the main menu.");
            if (CheckForEscKey()) return;
            int chosenPlayerID = InputNumCheck(playerIDRange.MaxPlayerID, playerIDRange.MinPlayerID, "Invalid player ID.");
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].PlayerID == chosenPlayerID)
                {
                    Console.WriteLine($"PLayer {players[i].PlayerNick} was deleted successfully.");
                    players.RemoveAt(i);
                    UpdatePlayerIDRange();
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("Players list is empty.");
        }
    }

    public void ChangeBanStatus()
    {
        if (players.Count > 0)
        {
            Console.WriteLine("Please select the player by ID whom you want to ban/unban or press the ESC key to return to the main menu.");
            if (CheckForEscKey()) return;
            int chosenPlayerID = InputNumCheck(playerIDRange.MaxPlayerID, playerIDRange.MinPlayerID, "Invalid player ID.");

            foreach (var player in players)
            {
                if (player.PlayerID == chosenPlayerID)
                {
                    player.UpdateBanStatus();
                    Console.WriteLine($"Player {(player.IsBanned ? "banned" : "unbanned")} successfully.");
                    return;
                }
            }
            Console.WriteLine("Player with the given ID was not found.");
        }
        else
        {
            Console.WriteLine("Players list is empty.");
        }
    }

    public void ShowAllPlayersInfo()
    {
        if (players.Count > 0)
        {
            foreach (var player in players)
            {
                player.PlayerInfo();
            }
        }
        else
        {
            Console.WriteLine("Players list is empty.");
        }
    }


    private int InputNumCheck(int maxValue, int minValue, string errorMessage)
    {
        int desiredNum;
        while (true)
        {
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out desiredNum) && desiredNum >= minValue && desiredNum <= maxValue)
                return desiredNum;

            Console.WriteLine(errorMessage);
        }
    }

    private bool CheckForEscKey()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("\nReturning to the main menu.");
            return true;
        }
        return false;
    }

    private void UpdatePlayerIDRange()
    {
        if (players.Count == 0)
        {
            playerIDRange = new PlayerIDRange(0, 0);
            return;
        }

        int playerIDMaxValue = players[0].PlayerID;
        int playerIDMinValue = players[0].PlayerID;

        for (int i = 1; i < players.Count; i++)
        {
            if (players[i].PlayerID > playerIDMaxValue)
            {
                playerIDMaxValue = players[i].PlayerID;
            }
            else if
            (players[i].PlayerID < playerIDMinValue)
            {
                playerIDMinValue = players[i].PlayerID;
            }
        }
        playerIDRange = new PlayerIDRange(playerIDMaxValue, playerIDMinValue);
    }

}

class Player
{
    private static int counter;
    public int PlayerID { get; private set; }
    public string PlayerNick { get; private set; }
    public int PlayerLvl { get; private set; }
    public bool IsBanned { get; private set; }

    public Player(string playerNick, int playerLvl)
    {
        PlayerNick = playerNick;
        PlayerLvl = playerLvl;
        PlayerID = ++counter;
        IsBanned = false;
    }

    public void UpdateBanStatus()
    {
        IsBanned = !IsBanned;
    }

    public void PlayerInfo()
    {
        string banStatus = IsBanned ? "is banned" : "is not banned";
        Console.WriteLine($"Player ID: {PlayerID}, player name: {PlayerNick}, player level: {PlayerLvl}, player {banStatus}");
    }
}