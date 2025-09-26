using Blackjack.models;

namespace Blackjack.Helpers
{
    public static class GameMasterHelper
    {
        public static bool CheckForBust(int totalScore)
        {
            bool isBusted = false;
            if (totalScore > 21)
            {
                isBusted = true;
            }
            return isBusted;
        }
        
        /// <summary>
        /// Handles the value assignment for an Ace card dealt to a player, ensuring the value is set correctly
        /// based on the player's current hand total and their input.
        /// </summary>
        /// <remarks>If assigning the Ace a value of 11 would cause the player's hand total to exceed 21,
        /// the Ace's value is automatically set to 1. Otherwise, the player is prompted to choose whether the Ace
        /// should count as 1 or 11 points.</remarks>
        /// <param name="player">The player who is receiving the Ace card.</param>
        /// <param name="card">The Ace card being dealt to the player. The card's value will be updated based on the player's choice or
        /// automatic rules.</param>
        /// <param name="playerCards">A dictionary containing the current cards held by each player, where the key is the player and the value is
        /// their list of cards.</param>
        public static void HandleAceValue(Player player, Card card, Dictionary<Player, List<Card>> playerCards)
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
