using Blackjack.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Managers
{
    public class Deck
    {
        private int NumberOfDecks = 0;
        private int NumberOfCardsInDeck = 52;
        Random random = new();
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
                            Value = GetCardValue(rank),
                            IsAce = rank == Card.CardRanks.Ace
                        });
                    }
                }
            }

            ShuffleDeck(deck);
            return deck;
        }
        public Card DealCards()
        {
            Card dealtCard = new Card();
            int cardIndex = random.Next(NumberOfCardsInDeck * NumberOfDecks);

            dealtCard = deck[cardIndex];
            deck.RemoveAt(cardIndex);

            Console.WriteLine($"Card {dealtCard.Rank} has been dealt to ???");
            return dealtCard;
        }

        // Helper method to assign card values
        private int GetCardValue(Card.CardRanks rank)
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
                Card.CardRanks.Ace => 11, // or 1
                _ => 0
            };
        }

        private void ShuffleDeck(List<Card> deck)
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
