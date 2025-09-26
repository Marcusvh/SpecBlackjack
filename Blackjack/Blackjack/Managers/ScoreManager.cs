using Blackjack.Helpers;
using Blackjack.Interfaces;
using Blackjack.models;

namespace Blackjack.Managers
{
    public class ScoreManager : IScoreManager
    {
        private readonly PlayerManager PlayerManager;
        
        public ScoreManager(PlayerManager playerMgr)
        {
            PlayerManager = playerMgr;
        }
        
        public void UpdatePlayerScore(Player player, Card card)
        {
            if (!PlayerManager.PlayerCards.ContainsKey(player))
                PlayerManager.PlayerCards[player] = new List<Card>();

            GameMasterHelper.HandleAceValue(player, card, PlayerManager.PlayerCards);
            PlayerManager.PlayerCards[player].Add(card);
            int totalScore = PlayerManager.GetPlayerScore(player);

            Console.WriteLine($"{player.Name} now has {totalScore} point{(totalScore == 1 ? "" : "s")}!\n");
        }
    }
}
