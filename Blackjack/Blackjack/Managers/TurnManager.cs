using Blackjack.Interfaces;
using Blackjack.models;

namespace Blackjack.Managers
{
    public class TurnManager : ITurnManager
    {
        private readonly PlayerManager playerManager = new PlayerManager();
        public TurnManager(PlayerManager player) 
        {
            playerManager = player;
        }
        public void ExecuteDealerTurn(DealerManager dealer, Card card)
        {
            dealer.TakeTurn(card);
        }

        /// <summary>
        /// Determines the action chosen by the player during their turn.
        /// </summary>
        /// <remarks>This method prompts the player to select an action during their turn. The available
        /// actions are  displayed as options, and the method waits for the player's input. The method will continue
        /// prompting  until a valid action is selected.</remarks>
        /// <param name="player">The player whose action is being determined. Must not be <see langword="null"/>.</param>
        /// <returns>A string representing the player's chosen action. Returns <c>"hit"</c> if the player chooses to hit,  or
        /// <c>"stand"</c> if the player chooses to stand.</returns>
        public string GetPlayerAction(Player player)
        {
            int playerScore = 0;
            while (true)
            {
                playerScore = playerManager.GetPlayerScore(player);
                Console.WriteLine($"It's {player.Name}'s turn with {playerScore} points");
                Console.WriteLine("Pick your action: \n1. Hit \n2. Stand");
                string userAction = Console.ReadLine();

                if (userAction == "1") return "hit";
                if (userAction == "2") return "stand";
            }
        }
    }
}
