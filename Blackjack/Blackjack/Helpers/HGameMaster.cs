using Blackjack.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Helpers
{
    public class HGameMaster
    {
        public bool CheckForBust(Player player, int totalScore)
        {
            bool isBusted = false;
            if (totalScore > 21)
            {
                Console.WriteLine($"{player.Name} has busted!");
                isBusted = true;
            }
            return isBusted;
        }
        public void CheckForBlackjack(string player, int totalScore)
        {
            if (totalScore == 21)
            {
                Console.WriteLine($"{player} has hit blackjack!");
            }
        }
        public void HandleAceValue(Player player, Card card, Dictionary<Player, List<Card>> playerCards)
        {
            int playerCurrentSum = playerCards[player].Sum(c => c.Value);
            if (card.IsAce && playerCurrentSum + 11 > 21)
            {
                card.Value = 1; // Automatically set ace to 1 if 11 would cause bust
            }
            else if (card.IsAce)
            {
                Console.WriteLine($"Your dealt card is an ace. You can choose if you want it to give 1 or 11 points. You currently have {playerCurrentSum} points");
                Console.WriteLine("1. 1 point \n2. 11 points");

                bool aceValuePicked = false;
                while (!aceValuePicked)
                {
                    string? input = Console.ReadLine();
                    if (input == "1")
                    {
                        card.Value = 1;
                        aceValuePicked = true;
                    }
                    else if (input == "2")
                    {
                        card.Value = 11;
                        aceValuePicked = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 1 or 2");
                    }
                }
            }
        }
    }
}
