using Advanced_War.Domain.GameTheory;
using Advanced_War.Domain.WarDeck;
using Advanced_War.Domain.WarDeck.Enums;

namespace Advanced_War.Domain.GameDevelopment;

public class GameEngine{
    private readonly List<Player> players;
    private readonly Deck deck;
    private int currentPlayerIndex = 0;
    private List<Card> cardsOnTable;
    public Player CurrentPlayer => players[currentPlayerIndex];

    public event EventHandler<GameEventArgs> GameStarted = null!;
    public event EventHandler<GameEventArgs> TurnStarted = null!;
    public event EventHandler<GameEventArgs> TurnEnded = null!;
    public event EventHandler<GameEventArgs> WarStarted = null!;
    public event EventHandler<GameEventArgs> GameEnded = null!;

    public GameEngine(List<Player> players)
    {
        if (players == null) throw new ArgumentNullException(nameof(players));
        
        if (players.Count != 2) throw new ArgumentException("Exactly two players are required for the game.");
        
        this.players = players;
        deck = new Deck();
    }
    
    public void StartNewGame()
    {
        deck.Shuffle();
        DealCards();
        cardsOnTable = new List<Card>();
        GameStarted?.Invoke(this, new GameEventArgs("Game started!"));
    }

    public async Task AutoPlayAsync(int autospeed)
    {
        this.TurnStarted += OnTurnStarted;
        this.GameEnded += OnGameEnded;

        if (deck.CardsLeft != 0)
        {
            StartNewGame();
        }

        async void OnTurnStarted(object sender, GameEventArgs e)
        {
            // Introduce a small delay to simulate thinking time
            await Task.Delay(autospeed);
            StartTurn();
        }

        void OnGameEnded(object sender, GameEventArgs e)
        {
            this.TurnStarted -= OnTurnStarted;
            this.GameEnded -= OnGameEnded;
        }

        StartTurn();
    }

    public void StartTurn()
    {
        if (players[0].CardCount == 0 || players[1].CardCount == 0)
        {
            throw new InvalidOperationException("Cannot start a new turn. One of the players has no cards left.");
        }

        if (currentPlayerIndex == 0)
        {
            WarStarted?.Invoke(this, new GameEventArgs("War has started!"));
        }

        TurnStarted?.Invoke(this, new GameEventArgs($"New turn started! Current player: {CurrentPlayer.Name}"));

        var card = CurrentPlayer.PlayCard();
        cardsOnTable.Add(card);
        
        if (cardsOnTable.Count % 2 == 0)
        {
            CompareCardsAndAssignWinner();
        }
        
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        // Check for game end
        if (players[0].CardCount == 0 || players[1].CardCount == 0)
        {
            var gameWinner = players[0].CardCount > 0 ? players[0] : players[1];
            GameEnded?.Invoke(this, new GameEventArgs($"Game winner: {gameWinner.Name}"));
        }
    }
    private void CompareCardsAndAssignWinner()
    {
        var firstPlayerLastPlayedCard = players[0].PlayedCards.Peek();
        var secondPlayerLastPlayedCard = players[1].PlayedCards.Peek();

        if (firstPlayerLastPlayedCard.Rank > secondPlayerLastPlayedCard.Rank)
        {
            players[0].AddCardToHand(cardsOnTable);
            TurnEnded?.Invoke(this, new GameEventArgs($"Player {players[0].Name} wins the round."));
            ClearGameRound();
        }
        else if (firstPlayerLastPlayedCard.Rank < secondPlayerLastPlayedCard.Rank)
        {
            players[1].AddCardToHand(cardsOnTable);
            TurnEnded?.Invoke(this, new GameEventArgs($"Player {players[1].Name} wins the round."));
            ClearGameRound();
        }
        else
        {
            TurnEnded?.Invoke(this, new GameEventArgs("It's a tie. Let's play on."));
        }
    }

    private void ClearGameRound()
    {
        cardsOnTable.Clear();
        players[0].ResetPlayedCards();
        players[1].ResetPlayedCards();
    }

    private void DealCards()
    {
        while (deck.CardsLeft > 0)
        {
            players[0].AddCardToHand(deck.Draw());
            players[1].AddCardToHand(deck.Draw());
        }
    }
}