using Blackjack.models;

namespace Blackjack.Helpers
{
    public class HDeck
    {
        public int GetCardValue(Card.CardRanks rank)
        {
            return rank switch
            {
                Card.CardRanks.Two => 2,
                Card.CardRanks.Three => 3,
                Card.CardRanks.Four => 4,
                Card.CardRanks.Five => 5,
                Card.CardRanks.Six => 6,
                Card.CardRanks.Seven => 7,
                Card.CardRanks.Eight => 8,
                Card.CardRanks.Nine => 9,
                Card.CardRanks.Ten => 10,
                Card.CardRanks.Jack => 10,
                Card.CardRanks.Queen => 10,
                Card.CardRanks.King => 10,
                Card.CardRanks.Ace => 11,
                _ => 0
            };
        }

        public void ShuffleDeck(List<Card> deck, Random random)
        {
            int n = deck.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (deck[i], deck[j]) = (deck[j], deck[i]);
            }
        }
    }
}
