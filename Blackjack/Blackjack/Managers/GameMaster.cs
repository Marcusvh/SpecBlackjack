using Blackjack.Helpers;
using Blackjack.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Managers
{
    public class GameMaster
    {
        HGameMaster HGameMaster = new HGameMaster();
        // Tracks each player's cards
        private readonly Dictionary<Player, List<Card>> playerCards = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMaster"/> class with the specified players.
        /// </summary>
        /// <remarks>The <paramref name="players"/> parameter must not be null, and each player name in
        /// the list must be unique.</remarks>
        /// <param name="players">A list of player names. Each player will be initialized with an empty hand of cards.</param>
        public GameMaster(List<Player> players)
        {
            foreach (Player player in players)
            {
                playerCards[player] = new List<Card>();
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Game started!");
            Console.WriteLine("Please enter the name(s) of the player(s)");
            while (true)
            {
                string? input = Console.ReadLine();
                Player player = new Player { Name = input};

                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input.ToLower() == "done")
                    {
                        break;
                    }
                    if (!playerCards.ContainsKey(player))
                    {
                        playerCards[player] = new List<Card>();
                        Console.WriteLine($"Player {input} added. Enter another name or type 'done' to finish.");
                    }
                    else
                    {
                        Console.WriteLine("This player name already exists. Please enter a different name, or type 'done' to finish");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid player name or type 'done' to finish.");
                }
            }

        }

        public void EndGame()
        {
            Console.WriteLine("Game ended!");
        }

        public bool UpdateScore(Player player, Card card)
        {
            if (!playerCards.ContainsKey(player))
            {
                playerCards[player] = new List<Card>();
            }

            HGameMaster.HandleAceValue(player, card, playerCards);

            playerCards[player].Add(card);
            int playerNewSum = playerCards[player].Sum(c => c.Value);
            int totalScore = playerNewSum;

            Console.WriteLine($"{player} now has {totalScore} point{(totalScore == 1 ? "" : "s")}!\n");

            return HGameMaster.CheckForBust(player, totalScore);
        } 
    }
}
