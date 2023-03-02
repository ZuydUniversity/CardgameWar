namespace War
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /*
            Deck deck = new Deck();

            foreach (var item in deck.Cards)
            {
                Console.WriteLine($"De kaart is {item.Suit} {item.Rank}");
            }

            deck.Shuffle();
            foreach (var item in deck.Cards)
            {
                Console.WriteLine($"De kaart is {item.Suit} {item.Rank}");
            }

            int i = 1;
            int j = 0;
            while (i <= 5)
            {
                i++;
                j++;
            }
            Console.WriteLine(j);

            */
            Dealer dealer = new Dealer(1);
            Console.WriteLine($"Aantal kaarten op hand: {dealer.HandOfCards.Count}");
            Console.WriteLine($"Aantal kaarten op deck: {dealer.DeckForTheGame.Cards.Count}");

            foreach (var card in dealer.DeckForTheGame.Cards)
            {
                Console.WriteLine($"Kaart {card.Suit} {card.Rank}");
            }

            var playedCard = dealer.PlayCard();
        }
    }
}