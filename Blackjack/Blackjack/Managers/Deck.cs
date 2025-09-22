using Blackjack.Helpers;
using Blackjack.models;

namespace Blackjack.Managers
{
    public class Deck
    {
        private int NumberOfDecks = 1;
        Random random = new();
        HDeck hDeck = new HDeck();
        List<Card> deck = new List<Card>();
        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class with the specified size.
        /// </summary>
        /// <param name="numberOfDecks">The number of decks, to be in play. The default value is 1.</param>
        public Deck(int numberOfDecks = 1) 
        {
            NumberOfDecks = numberOfDecks;
        }

        public List<Card> GetDeckOfCards()
        {
            int id = 1;

            for (int d = 0; d < NumberOfDecks; d++)
            {
                foreach (Card.CardRanks rank in Enum.GetValues(typeof(Card.CardRanks)))
                {
                    for (int i = 0; i < 4; i++) // 4 of each rank (for 4 suits), even when suits dont matter. but still need a full deck
                    {
                        deck.Add(new Card
                        {
                            Id = id++,
                            Rank = rank,
                            Value = hDeck.GetCardValue(rank),
                            IsAce = rank == Card.CardRanks.Ace
                        });
                    }
                }
            }

            hDeck.ShuffleDeck(deck, random);
            return deck;
        }
        public Card DealCards(string player)
        {
            Card dealtCard = new Card();
            int cardIndex = random.Next(0, deck.Count * NumberOfDecks);

            dealtCard = deck[cardIndex];
            deck.RemoveAt(cardIndex);

            Console.WriteLine($"{dealtCard.Rank} has been dealt to {player}");
            return dealtCard;
        }   
    }
}
