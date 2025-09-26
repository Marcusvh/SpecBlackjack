using Blackjack.Managers;
using Blackjack.models;

namespace Blackjack.Interfaces
{
    public interface ITurnManager
    {
        public string GetPlayerAction(Player player);
        public void ExecuteDealerTurn(DealerManager dealer, Card card);
    }
}
