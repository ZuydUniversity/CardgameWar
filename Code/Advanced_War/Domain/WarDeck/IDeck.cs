namespace Advanced_War.Domain.WarDeck;

public interface IDeck
{
    List<Card> Cards { get; }
    void Shuffle();
    Card Draw();
}