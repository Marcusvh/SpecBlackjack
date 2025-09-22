using Blackjack.Managers;
using Blackjack.models;

Console.WriteLine("Welcome to blackjack");

List<string> players = new List<string> { "Player 1"};
Deck deck = new Deck();
GameMaster gameMaster = new GameMaster(players);
deck.GetDeckOfCards();
Card dealtCards = deck.DealCards();
gameMaster.UpdateScore("Player 1", dealtCards);