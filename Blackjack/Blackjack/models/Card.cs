using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.models
{
    public class Card
    {
        public enum CardRanks
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }
        public int Id { get; set; }
        public CardRanks Rank { get; set; }
        public int Value { get; set; }
        public bool IsAce { get; set; }
    }
}
