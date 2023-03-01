using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oorlog
{
    public class Player
    {
        public int PlayerNumber { get; set; }
        public List<Card> HandOfCards { get; set; }

        public Player(int id)
        {
            PlayerNumber = id;
            HandOfCards = new List<Card>();
        }

        public virtual Card? PlayCard()
        {
            if (HandOfCards.Count > 0)
            {
                return HandOfCards[0];
            }
            return null;
        }

    }
}
