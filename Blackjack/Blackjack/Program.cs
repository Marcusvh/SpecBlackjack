using Blackjack.Helpers;
using Blackjack.Managers;
using Blackjack.models;

Console.WriteLine("Welcome to blackjack");

Deck deck = new Deck();
deck.GetDeckOfCards();
PlayerManager playerManager = new PlayerManager();
DealerManager dealerManager = new();
GameMaster gameMaster = new GameMaster(dealerManager, playerManager);
TurnManager turnManager = new TurnManager(playerManager);
ScoreManager scoreManager = new ScoreManager(playerManager);

gameMaster.StartGame();

// Handle user input and add players
while (true)
{
    Console.WriteLine("Enter player name (or 'done' to finish):");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "done")
        break;
    try
    {
        playerManager.AddPlayer(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Track player states: "active", "stand", "bust"
Dictionary<string, string> playerStates = playerManager.Players.ToDictionary(p => p.Name, p => "active");
bool continueGame = true;

while (continueGame)
{
    foreach (var player in playerManager.Players)
    {
        if (playerStates[player.Name] != "active")
            continue;

        string action = turnManager.GetPlayerAction(player);
        if (action == "hit")
        {
            Card dealtCard = deck.DealCards(player.Name);
            scoreManager.UpdatePlayerScore(player, dealtCard);

            int playerScore = playerManager.GetPlayerScore(player);
            if (GameMasterHelper.CheckForBust(playerScore))
            {
                playerStates[player.Name] = "bust";
            }
        }
        else if (action == "stand")
        {
            playerStates[player.Name] = "stand";
        }
    }

    // Dealer's turn after all players are done
    if (playerStates.Values.All(state => state != "active"))
    {
        int dealerScore = dealerManager.GetScore();
        bool dealerTurnOver = false;
        while (!dealerTurnOver)
        {
            Card dealtCard = deck.DealCards(dealerManager.Dealer.Name);
            turnManager.ExecuteDealerTurn(dealerManager, dealtCard);
            dealerScore = dealerManager.GetScore();

            if (GameMasterHelper.CheckForBust(dealerScore))
            {
                gameMaster.EndGame();

                continueGame = false;
                dealerTurnOver = true;
                break;
            }

            if (dealerScore >= 17)
            {
                Console.WriteLine($"The dealer stands with {dealerScore} points\n");
                gameMaster.EndGame();
                
                continueGame = false;
                dealerTurnOver = true;
                break;
            }
        }
    }
}