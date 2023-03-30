using Advanced_War.Domain.WarDeck;

namespace Advanced_War.Domain.GameTheory;

public class Player
{
    private List<Card> hand;
    
    private Random random;
    public int Id { get; set; }
    public string Name { get; init; }
    public int Wins { get; private set; }
    public int Games { get; private set; }
    
    public Stack<Card> PlayedCards { get; private set; } = new Stack<Card>();

    public Player(string name)
    {
        Name = name;
    }
    
    public Player(int playerNumber, string playerName, int wins, int games) : this(playerName)
    {
        Id = playerNumber;
        Wins = wins;
        Games = games;
        hand = new List<Card>();
        random = new Random();
    }

    public void AddPlayedGame(bool victory)
    {
        Games++;
        Wins = victory ? Wins + 1 : Wins;
    }
    
    
    public void AddCardToHand(List<Card> cards)
    {
        foreach (var card in cards)
        {
            this.AddCardToHand(card);
        }
    }
    
    public void AddCardToHand(Card card)
    {
        if (card == null)
        {
            throw new ArgumentNullException(nameof(card));
        } 
        
        this.hand.Add(card);
    }

    public void ResetPlayedCards()
    {
        this.PlayedCards.Clear();
    }

    public Card PlayCard()
    {
        if (this.hand.Count == 0)
        {
            throw new InvalidOperationException("Player has no cards left to play.");
        }

        int randomIndex = random.Next(hand.Count);
        Card selectedCard = hand[randomIndex];
        hand.RemoveAt(randomIndex);
        this.PlayedCards.Push(selectedCard);

        return selectedCard;
    }

    public int CardCount => this.hand.Count;
}