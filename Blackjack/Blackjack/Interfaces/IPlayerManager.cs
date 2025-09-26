using Blackjack.models;

namespace Blackjack.Interfaces
{
    public interface IPlayerManager
    {
        public void AddPlayer(string name);
        public List<Card> GetPlayerCards(Player player);
        public int GetPlayerScore(Player player);

    }
}
