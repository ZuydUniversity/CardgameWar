using Advanced_War.Domain.GameTheory;
using Advanced_War.Domain.WarDeck;

namespace Advanced_War.Domain.GameDevelopment;

public class GameEngine{
    private readonly List<Player> players;
    private readonly Deck deck;

    public event EventHandler<GameEventArgs> GameStarted = null!;
    public event EventHandler<GameEventArgs> RoundStarted = null!;
    public event EventHandler<GameEventArgs> RoundEnded = null!;
    public event EventHandler<GameEventArgs> WarStarted = null!;
    public event EventHandler<GameEventArgs> GameEnded = null!;

    public GameEngine(List<Player> players)
    {
        if (players == null) throw new ArgumentNullException(nameof(players));
        
        if (players.Count != 2) throw new ArgumentException("Exactly two players are required for the game.");
        
        this.players = players;
        deck = new Deck();
    }

    public void StartGame()
    {
        deck.Shuffle();
        DealCards();

        GameStarted?.Invoke(this, new GameEventArgs("Game started!"));

        while (players[0].CardCount > 0 && players[1].CardCount > 0)
        {
            RoundStarted?.Invoke(this, new GameEventArgs("New round started!"));

            var playerOnePlayedCard = players[0].PlayCard();
            var playerTwoPlayedCard = players[1].PlayCard();

            var cardsOnTable = new List<Card> { playerOnePlayedCard, playerTwoPlayedCard };

            while (playerOnePlayedCard.Rank == playerTwoPlayedCard.Rank)
            {
                WarStarted?.Invoke(this, new GameEventArgs("War started!"));

                if (players[0].CardCount < 4 || players[1].CardCount < 4)
                {
                    // Player with more cards wins if either player has fewer than 4 cards
                    break;
                }

                for (var i = 0; i < 3; i++)
                {
                    cardsOnTable.Add(players[0].PlayCard());
                    cardsOnTable.Add(players[1].PlayCard());
                }

                playerOnePlayedCard = players[0].PlayCard();
                playerTwoPlayedCard = players[1].PlayCard();

                cardsOnTable.Add(playerOnePlayedCard);
                cardsOnTable.Add(playerTwoPlayedCard);
            }

            var roundWinner = playerOnePlayedCard.Rank > playerTwoPlayedCard.Rank ? players[0] : players[1];

            foreach (var card in cardsOnTable)
            {
                roundWinner.AddCardToHand(card);
            }

            RoundEnded?.Invoke(this, new GameEventArgs($"Round winner: {roundWinner.Name}"));
        }

        var gameWinner = players[0].CardCount > 0 ? players[0] : players[1];
        var gameLoser = players[0].CardCount == 0 ? players[0] : players[1];
        gameWinner.AddPlayedGame(true);
        gameLoser.AddPlayedGame(false);
        GameEnded?.Invoke(this, new GameEventArgs($"Game winner: {gameWinner.Name}"));
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