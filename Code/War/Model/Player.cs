using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Model
{
    /// <summary>
    /// Represents a player of the game
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The unique number of the player
        /// </summary>
        public int PlayerNumber { get; private set; }
        /// <summary>
        /// The unique name of the player
        /// </summary>
        public string PlayerName { get; private set; }
        /// <summary>
        /// The number of wins of the player
        /// </summary>
        public int Wins { get; private set; }
        /// <summary>
        /// The number of games the player played
        /// </summary>
        public int Games { get; private set; }
        /// <summary>
        /// The current game of the player
        /// </summary>
        public Game? CurrentGame { private get; set; }
        /// <summary>
        /// The cards the player has on hand
        /// </summary>
        public Queue<Card> CardsOnHand { get; set; }

        /// <summary>
        /// Constructor to create a player
        /// </summary>
        /// <param name="playerName">The name of the player</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Player(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentNullException(nameof(playerName), playerName);
            }
            PlayerName = playerName;
            CurrentGame = null;
            CardsOnHand = new Queue<Card>();
        }

        /// <summary>
        /// Reset the cards on hand (empty)
        /// </summary>
        public void ResetCardsOnHand()
        {
            CardsOnHand = new Queue<Card> { };
        }

        /// <summary>
        /// Receive a card an put on hand
        /// </summary>
        /// <param name="card"></param>
        public void ReceiveCard(Card card)
        {
            if (card != null)
            {
                card.Player = this;
                CardsOnHand.Enqueue(card);
            }
        }

        /// <summary>
        /// Play the first card on hand
        /// </summary>
        /// <returns>The card, null if hand is empty</returns>
        public virtual Card? PlayCard()
        {
            if (CardsOnHand.Count > 0)
            {
                var c = CardsOnHand.Dequeue();
                c.Player = null;
                return c;
            }
            return null;
        }

        /// <summary>
        /// Play three war cards
        /// </summary>
        /// <returns>The three cards to play, null when not enough cards</returns>
        public virtual Queue<Card>? PlayWarCards()
        {
            Queue<Card> cardsToPlay = new Queue<Card>();
            if (CardsOnHand.Count > 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    var c = CardsOnHand.Dequeue();
                    c.Player = null;
                    cardsToPlay.Enqueue(c);
                }
                return CardsOnHand;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add the score to the player
        /// </summary>
        /// <param name="win"></param>
        public void AddScore(bool win)
        {
            Games++;
            Wins = win ? Wins + 1 : Wins;
        }
    }
}
