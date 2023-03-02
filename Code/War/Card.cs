using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public Deck Deck { get; set; }

        public Card()
        {

        }
    }
}
