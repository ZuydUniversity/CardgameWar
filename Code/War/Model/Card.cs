using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Model
{
    /// <summary>
    /// Class representing a playing card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Suit of the card
        /// </summary>
        public Suit Suit { get; private set; }
        /// <summary>
        /// Rank of the card
        /// </summary>
        public Rank Rank { get; private set; }
        /// <summary>
        /// The deck the card belongs to
        /// </summary>
        public Deck? Deck { get; set; }
        /// <summary>
        /// The player the card belongs to
        /// </summary>
        public Player? Player { get; set; }

        public Card(Suit suit, Rank rank, Deck deck)
        {
            Suit = suit;
            Rank = rank;
            Deck = deck;
            Player = null;
        }
    }
}
