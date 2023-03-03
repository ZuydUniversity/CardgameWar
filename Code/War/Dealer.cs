using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class Dealer : Player
    {
        public Deck DeckForTheGame { get; set; }

        public Dealer(int id) : base(id) 
        {
            this.DeckForTheGame = new Deck(null);
        }

        public override Card? PlayCard()
        {
            var resultaat = base.PlayCard();

            if (resultaat == null) 
            {
                return new Card(Suit.Hearts, Rank.Ace, null);
            }
            else
            {
                return resultaat;
            }
            
        }
    }
}
