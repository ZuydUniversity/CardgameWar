using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Model
{
    /// <summary>
    /// A deck of cards
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// The cards
        /// </summary>
        private Queue<Card> Cards { get; set; }
        /// <summary>
        /// The game the deck is used in
        /// </summary>
        private Game Game { get; set; }

        /// <summary>
        /// Constructor: create the full deck of cards
        /// </summary>
        public Deck(Game game)
        {
            // initialize
            Game = game;
            Cards = new Queue<Card>();

            // create the deck
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Enqueue(new Card(s, r, this));
                }
            }
        }

        /// <summary>
        /// Shuffle the cards
        /// </summary>
        public void ShuffleCards()
        {
            List<Card>? cardsToList = Cards.ToList();
            Random random = new Random();
            Queue<Card> newQueue = new Queue<Card>();
            int cnt = Cards.Count;
            for (int i = 0; i < cnt; i++)
            {
                int randomElementInList = random.Next(0, cardsToList.Count);
                newQueue.Enqueue(cardsToList[randomElementInList]);
                cardsToList.Remove(cardsToList[randomElementInList]);
            }
            Cards = newQueue;
        }

        /// <summary>
        /// Give a 
        /// </summary>
        /// <returns>The card or null when no cards on deck</returns>
        public Card? GetCard()
        {
            if (Cards.Count > 0)
            {
                var c = Cards.Dequeue();
                // card will leave the deck so set to null
                c.Deck = null;
                return c;
            }
            return null;
        }

        /// <summary>
        /// Receive a card for the deck
        /// </summary>
        /// <param name="card">The card to receive</param>
        public void ReceiveCard(Card card)
        {
            Cards.Enqueue((Card)card);
        }
    }
}
