using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();

            var c = new Card();
            c.Rank = "jack";
            c.Suit = "hearts";

            for (int i = 1; i < 14; i++)
            {
                Cards.Add(new Card() { Suit = "clubs", Rank = i.ToString() });
            }

            Cards.Add(c);
        }

        /// <summary>
        /// Shuffle the cards
        /// </summary>
        public void Shuffle()
        {
            var random = new Random();
            var newShuffledList = new List<Card>();
            var listcCount = Cards.Count;
            for (int i = 0; i < listcCount; i++)
            {
                var randomElementInList = random.Next(0, Cards.Count);
                newShuffledList.Add(Cards[randomElementInList]);
                Cards.Remove(Cards[randomElementInList]);
            }
            Cards = newShuffledList;
        }
    }
}
