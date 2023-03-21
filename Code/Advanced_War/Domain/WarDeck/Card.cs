using Advanced_War.Domain.WarDeck.Enums;

namespace Advanced_War.Domain.WarDeck;

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public int GetValue()
    {
        return (int)Rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}