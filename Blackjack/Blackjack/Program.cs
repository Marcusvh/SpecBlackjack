using Blackjack.Managers;
using Blackjack.models;

Console.WriteLine("Welcome to blackjack");

List<string> players = new List<string> { "Player 1" };
Deck deck = new Deck();
deck.GetDeckOfCards();
GameMaster gameMaster = new GameMaster(players);

while (true)
{
    Card dealtCards = deck.DealCards(players[0]);
    bool isBusted = gameMaster.UpdateScore("Player 1", dealtCards);
    if (isBusted)
    {
        gameMaster.EndGame();
        break;
    }
}