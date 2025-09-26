using Blackjack.models;

namespace Blackjack.Interfaces
{
    public interface IDealerManager
    {
        public List<Card> DealerHand { get; }
        public int GetScore();
        public void TakeTurn(Card card);

    }
}
