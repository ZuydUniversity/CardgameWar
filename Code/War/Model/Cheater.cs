using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Model
{
    public class Cheater : Player
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="playerName">The name of the player</param>
        public Cheater(string playerName) : base(playerName)
        {
        }

        /// <summary>
        /// Play the first card on hand
        /// </summary>
        /// <returns>The card, null if hand is empty</returns>
        //public override Card? PlayCard()
        //{
        //    if (CardsOnHand.Count > 0)
        //    {
        //        var c = CardsOnHand.Dequeue();
        //        c.Player = null;
        //        return c;
        //    }
        //    return null;
        //}
        //
        ///// <summary>
        ///// Play three war cards
        ///// </summary>
        ///// <returns>The three cards to play, null when not enough cards</returns>
        //public override Queue<Card>? PlayWarCards()
        //{
        //    Queue<Card> cardsToPlay = new Queue<Card>();
        //    if (CardsOnHand.Count > 2)
        //    {
        //        for (int i = 0; i < 3; i++)
        //        {
        //            var c = CardsOnHand.Dequeue();
        //            c.Player = null;
        //            cardsToPlay.Enqueue(c);
        //        }
        //        return CardsOnHand;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
