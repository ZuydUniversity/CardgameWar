using Advanced_War.Domain.WarDeck.Enums;

namespace Advanced_War.Domain.WarDeck;

public class Deck : IDeck
{
    public List<Card> Cards { get; private set; }
    public int CardsLeft => Cards.Count;
    
    public Deck()
    {
        Cards = CreateCards();
        Shuffle();
    }

    private List<Card> CreateCards()
    {
        return (from Suit suit in Enum.GetValues(typeof(Suit)) from Rank rank in Enum.GetValues(typeof(Rank)) select new Card(suit, rank)).ToList();
    }

    public void Shuffle()
    {
        var random = new Random();
        for (var i = Cards.Count - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (Cards[i], Cards[j]) = (Cards[j], Cards[i]);
        }
    }

    public Card Draw()
    {
        if (Cards.Count == 0)
        {
            throw new InvalidOperationException("Cannot draw a card from an empty deck.");
        }

        var card = Cards[0];
        Cards.RemoveAt(0);
        return card;
    }
}