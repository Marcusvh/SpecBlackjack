using Blackjack.models;

namespace Blackjack.Helpers
{
    public static class ScoreHelper
    {
        public static string GetPlayerResult(int playerScore, int dealerScore)
        {
            if (playerScore > 21) return "Busted";
            if (dealerScore > 21) return "Dealer busted, player wins";
            if (playerScore > dealerScore) return "Win";
            if (playerScore == dealerScore) return "Draw";
            return "Lose";
        }

        public static List<(Player Player, int Score, string Result)> GetPlayerResults(
    List<Player> players, int dealerScore, Func<Player, int> getPlayerScore)
        {
            // Sorting players by their scores
            return players
                .Select(p => (
                    Player: p,
                    Score: getPlayerScore(p),
                    Result: GetPlayerResult(getPlayerScore(p), dealerScore)
                ))
                .OrderByDescending(x => x.Score > 21 ? 0 : x.Score) // if busted, treat score as 0 for sorting
                .ToList();
        }

        public static List<(string Name, int Score)> GetFinalRankings(
            List<(Player Player, int Score, string Result)> playerResults, int dealerScore)
        {
            // Sorting Final ranking (including dealer)
            return playerResults
                .Select(x => (Name: x.Player.Name, Score: x.Score))
                .Append((Name: "Dealer", Score: dealerScore))
                .OrderByDescending(x => x.Score > 21 ? 0 : x.Score) // if busted, treat score as 0 for sorting
                .ToList();
        }
    }
}
