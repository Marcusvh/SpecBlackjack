using Blackjack.Interfaces;
using Blackjack.models;

namespace Blackjack.Managers
{
    public class PlayerManager : IPlayerManager
    {
        public List<Player> Players { get; } = new();
        public Dictionary<Player, List<Card>> PlayerCards { get; } = new();

        public void AddPlayer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Player name cannot be empty.", nameof(name));
            if (Players.Any(p => p.Name == name))
                throw new InvalidOperationException("This player name already exists.");

            var player = new Player { Name = name };
            Players.Add(player);
            PlayerCards[player] = new List<Card>();
            Console.WriteLine($"Player {name} added.");
        }

        public List<Card> GetPlayerCards(Player player)
        {
            return PlayerCards[player];
        }

        public int GetPlayerScore(Player player)
        {
            return PlayerCards[player].Sum(c => c.Value);
        }
    }
}
