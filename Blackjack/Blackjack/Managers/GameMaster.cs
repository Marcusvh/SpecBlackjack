using Blackjack.Helpers;

namespace Blackjack.Managers
{
    public class GameMaster
    {
        private DealerManager dealerManager = new DealerManager();
        private PlayerManager playerManager = new PlayerManager();

        public GameMaster(DealerManager dealer, PlayerManager player)
        {
            dealerManager = dealer;
            playerManager = player;
        }
        // Optional later implementation for start game setup
        public void StartGame()
        {
            Console.WriteLine("Game started!");
        }

        // Optional later implementation for end game cleanup or other things
        public void EndGame()
        {
            Console.WriteLine("Game ended!");
            
            AnnounceResults();
        }
        // Optional later implementation for handling game draw in different scenarios
        public void GameDraw()
        {
            Console.WriteLine("Game draw");

            AnnounceResults();
        }

        /// <summary>
        /// Announces the results of the game, including player scores, outcomes, and final rankings.
        /// </summary>
        /// <remarks>This method retrieves the dealer's score and calculates the results for all players
        /// based on their scores. It then displays the results for each player, indicating whether they have busted or
        /// their final outcome. Finally, it announces the overall rankings, including the dealer, sorted by
        /// score.</remarks>
        public void AnnounceResults()
        {
            int dealerScore = dealerManager.GetScore();

            // Sorting players by their scores
            var playerResults = ScoreHelper.GetPlayerResults(playerManager.Players, dealerScore, playerManager.GetPlayerScore);

            // Announce player results
            Console.WriteLine("\n--- Player Results ---");
            foreach (var pr in playerResults)
            {
                if (pr.Score > 21)
                    Console.WriteLine($"{pr.Player.Name} busted with {pr.Score} points.");
                else
                    Console.WriteLine($"{pr.Player.Name}: {pr.Score} points - {pr.Result}");
            }
            
            // Sorting Final ranking (including dealer)
            var allResults = ScoreHelper.GetFinalRankings(playerResults, dealerScore);

            // Announce final rankings
            Console.WriteLine("\n--- Final Rankings ---");
            for (int i = 0; i < allResults.Count; i++)
            {
                var place = i + 1;
                if (allResults[i].Score > 21)
                    Console.WriteLine($"{place}. {allResults[i].Name} - Busted");
                else
                    Console.WriteLine($"{place}. {allResults[i].Name} - {allResults[i].Score} points");
            }
        }

    }
}
