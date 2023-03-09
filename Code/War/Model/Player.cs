using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.DataAccess;

namespace War.Model
{
    /// <summary>
    /// Represents a player of the game
    /// </summary>
    public class Player
    {
        private int playerNumber;
        /// <summary>
        /// The unique number of the player
        /// </summary>
        public int PlayerNumber {
            get { return playerNumber; }  
            set
            {
                if (playerNumber == 0)
                {
                    playerNumber = value;
                }
                else
                {
                    throw new Exception("Not allowed to change player number!");
                }
            }
        }

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
        private readonly Queue<Card> cardsOnHand;

        /// <summary>
        /// The number of cards on hand
        /// </summary>
        public int CardCount 
        { 
            get {  return cardsOnHand.Count; }
        }

        /// <summary>
        /// Constructor to create a player
        /// </summary>
        /// <param name="playerName">The required name of the player</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Player(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentNullException(nameof(playerName), playerName);
            }
            PlayerName = playerName;
            CurrentGame = null;
            cardsOnHand = new Queue<Card>();
            Wins = 0;
            Games = 0;
        }

        public Player(int playerNumber, string playerName, int wins, int games) : this(playerName)
        {
            this.PlayerNumber = playerNumber;
            Wins = wins;
            Games = games;
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
                cardsOnHand.Enqueue(card);
            }
        }

        /// <summary>
        /// Play the first card on hand
        /// </summary>
        /// <returns>The card, null if hand is empty</returns>
        public virtual Card? PlayCard()
        {
            if (cardsOnHand.Count > 0)
            {
                var c = cardsOnHand.Dequeue();
                c.Player = null;
                return c;
            }
            return null;
        }

        /// <summary>
        /// Play four war cards. Play all cards if less than four cards available
        /// </summary>
        /// <returns>The four cards to play</returns>
        public virtual Queue<Card> PlayWarCards()
        {
            Queue<Card> cardsToPlay = new Queue<Card>();

            int count = Math.Min(cardsOnHand.Count, 4);
            for (int i = 0; i < count; i++)
            {
                var c = cardsOnHand.Dequeue();
                c.Player = null;
                cardsToPlay.Enqueue(c);
            }
            return cardsToPlay;
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

        // data access

        /// <summary>
        /// Persist the player in the data layer
        /// </summary>
        public void CreatePlayerData()
        {
            if (this.playerNumber == 0)
            {
                IDAL dal = new DataAccessLayer();
                dal.CreatePlayerData(this);
            }
        }

        /// <summary>
        /// Read all players from data access layer
        /// </summary>
        /// <returns>The list of all players</returns>
        public static List<Player> ReadPlayersData()
        {
            IDAL dal = new DataAccessLayer();
            return dal.ReadPlayersData();
        }

        /// <summary>
        /// Read a specific player from the data access layer
        /// </summary>
        /// <param name="playerNumber">The number of the player</param>
        /// <returns>The player</returns>
        public static Player? ReadPlayerData(int playerNumber)
        {
            IDAL dal = new DataAccessLayer();
            return dal.ReadPlayerData(playerNumber);
        }

        /// <summary>
        /// Update the player in the data access layer
        /// </summary>
        public void UpdatePlayerData()
        {
            IDAL dal = new DataAccessLayer();
            dal.UpdatePlayerData(this);
        }

        /// <summary>
        /// Delete player from data access layer
        /// </summary>
        /// <param name="playerNumber">The number of the player to delete</param>
        public static void DeletePlayerData(int playerNumber)
        {
            IDAL dal = new DataAccessLayer();
            dal.DeletePlayerData(playerNumber);
        }
    }
}
