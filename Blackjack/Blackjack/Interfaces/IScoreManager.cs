using Blackjack.models;

namespace Blackjack.Interfaces
{
    public interface IScoreManager
    {
        public void UpdatePlayerScore(Player player, Card card);
    }
}
