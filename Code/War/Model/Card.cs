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

        public override string ToString()
        {
            return $"{Suit}_{Rank}";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="suit">The suit of the card</param>
        /// <param name="rank">The rank of the card</param>
        /// <param name="deck">The deck, can be null</param>
        /// <param name="player">The player, can be null</param>
        public Card(Suit suit, Rank rank, Deck? deck, Player? player)
        {
            Suit = suit;
            Rank = rank;

            // Player or deck should be filled
            if (deck == null && player == null)
                throw new ArgumentException("Player or deck should not be null");

            Deck = deck;
            Player = player;
        }
    }
}
