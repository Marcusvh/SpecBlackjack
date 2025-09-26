using Blackjack.Interfaces;
using Blackjack.models;

namespace Blackjack.Managers
{
    public class DealerManager : IDealerManager
    {
        public List<Card> DealerHand { get; } = new();
        public Player Dealer { get; private set; } = new Player { Name = "Dealer" };

        public int GetScore()
        {
            return DealerHand.Sum(card => card.Value);
        }

        public void TakeTurn(Card card)
        {
            DealerHand.Add(card);
            int dealerScore = DealerHand.Sum(c => c.Value);
            Console.WriteLine($"Dealer now has {dealerScore} point{(dealerScore == 1 ? "" : "s")}!\n");
        }
    }
}
