using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oorlog
{
    public class Dealer : Player
    {
        public Deck DeckForTheGame { get; set; }

        public Dealer(int id) : base(id) 
        {
            this.DeckForTheGame = new Deck();
        }

        public override Card? PlayCard()
        {
            var resultaat = base.PlayCard();

            if (resultaat == null) 
            {
                return new Card() { Rank = "Ace", Suit = "Hearts" };
            }
            else
            {
                return resultaat;
            }
            
        }
    }
}
