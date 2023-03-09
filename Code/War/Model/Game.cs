using War.Exceptions;

namespace War.Model
{
    /// <summary>
    /// Represents the actual game to be played
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The deck to play with
        /// </summary>
        private readonly Deck deck;
        /// <summary>
        /// Player one
        /// </summary>
        private readonly Player playerOne;
        /// <summary>
        /// Cards played by player one. Stack because order should be contained (LIFO)
        /// </summary>
        public Stack<Card> PlayerOnePlayedCards { get; private set; }
        /// <summary>
        /// Player two
        /// </summary>
        private readonly Player playerTwo;
        /// <summary>
        /// Cards played by player two. Stack because order should be contained (LIFO)
        /// </summary>
        public Stack<Card> PlayerTwoPlayedCards { get; private set; }

        private Player? winner;
        /// <summary>
        /// The winner of the game, null when game in progress/ no winner
        /// Change score of players when setting the winner
        /// </summary>
        public Player? Winner
        {
            get
            {
                return winner;
            }
            set
            {
                if (value != null)
                {
                    playerOne.AddScore(value.Equals(playerOne));
                    playerTwo.AddScore(value.Equals(playerTwo));
                    GameStarted = false;
                }
                winner = value;
            }
        }

        /// <summary>
        /// Wich players turn? 1 or 2
        /// </summary>
        public PlayerTurn Turn { get; private set; }

        /// <summary>
        /// While endGame is false the game continues
        /// </summary>
        private bool endGame;

        /// <summary>
        /// Shows is the game has started
        /// </summary>
        public bool GameStarted { get; private set; }

        public Game(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne ?? throw new ArgumentNullException(nameof(playerOne));
            this.playerOne.CurrentGame = this;
            PlayerOnePlayedCards = new Stack<Card>();
            this.playerTwo = playerTwo ?? throw new ArgumentNullException(nameof(playerTwo));
            this.playerTwo.CurrentGame = this;
            PlayerTwoPlayedCards = new Stack<Card>();

            Winner = null;
            endGame = false;
            Turn = PlayerTurn.None;

            deck = new Deck(this);
            deck.ShuffleCards();

            GameStarted = false;
        }

        /// <summary>
        /// Make everything ready to start the game
        /// See SD: Start game
        /// </summary>
        public void StartGame()
        {
            // reset winner
            Winner = null;

            // get all cards back from players
            ReturnCardsFromPlayer(playerOne);
            ReturnCardsFromPlayer(playerTwo);

            // check cards on table
            for (int i = 0; i < PlayerOnePlayedCards.Count; i++)
            {
                deck.ReceiveCard(PlayerOnePlayedCards.Pop());
            }
            for (int i = 0; i < PlayerTwoPlayedCards.Count; i++)
            {
                deck.ReceiveCard(PlayerTwoPlayedCards.Pop());
            }

            // restart game
            DetermineStartPlayer();
            deck.ShuffleCards();
            DealCards();
            GameStarted = true;
        }

        /// <summary>
        /// Deal all the cards of the deck
        /// </summary>
        private void DealCards()
        {
            if (deck == null)
                throw new NullReferenceException(nameof(deck));

            Card? card = deck.GetCard();
            PlayerTurn startDealingPlayer = Turn == PlayerTurn.PlayerOne ? PlayerTurn.PlayerTwo : PlayerTurn.PlayerOne;
            while (card != null)
            {
                switch (startDealingPlayer)
                {
                    case PlayerTurn.PlayerOne:
                        playerOne.ReceiveCard(card);
                        startDealingPlayer = PlayerTurn.PlayerTwo;
                        break;
                    case PlayerTurn.PlayerTwo:
                        playerTwo.ReceiveCard(card);
                        startDealingPlayer = PlayerTurn.PlayerOne;
                        break;
                    default:
                        break;
                }
                card = deck.GetCard();
            }
        }

        /// <summary>
        /// Set the turn of the game to the starting player randomly
        /// </summary>
        private void DetermineStartPlayer()
        {
            Random r = new Random();
            Turn = (PlayerTurn)(r.Next(1) + 1);
        }

        /// <summary>
        /// Play a round
        /// </summary>
        /// <returns>The winner of the round</returns>
        /// <exception cref="GameStoppedException">The game has stopped</exception>
        public PlayerTurn PlayRound()
        {
            // just in case there are still cards on the table
            HandCardsToWinningPlayer();

            if (endGame)
            {
                throw new GameStoppedException("Game has ended!");
            }
            if (Winner != null)
            {
                throw new GameStoppedException($"Player {Winner.PlayerName} won!");
            }
            if (!GameStarted)
            {
                throw new GameStoppedException($"Game not even started!");
            }

            // play a round
            // stop as soon there is a winner
            bool noGameWinner = true;
            PlayerTurn roundWinner = PlayerTurn.None;
            switch (Turn)
            {
                case PlayerTurn.PlayerOne:
                    noGameWinner = noGameWinner && PlayCard(playerOne, PlayerOnePlayedCards);
                    if (noGameWinner)
                    {
                        noGameWinner = noGameWinner && PlayCard(playerTwo, PlayerTwoPlayedCards);
                        if (!noGameWinner)
                        {
                            roundWinner = PlayerTurn.PlayerOne;
                            Winner = playerOne;
                        }
                    }
                    else
                    {
                        // player one has no cards so player two wins
                        roundWinner = PlayerTurn.PlayerTwo;
                        Winner = playerTwo;
                    }
                    break;
                case PlayerTurn.PlayerTwo:
                    noGameWinner = noGameWinner && PlayCard(playerTwo, PlayerTwoPlayedCards);
                    if (noGameWinner)
                    {
                        noGameWinner = noGameWinner && PlayCard(playerOne, PlayerOnePlayedCards);
                        if (!noGameWinner)
                        {
                            roundWinner = PlayerTurn.PlayerTwo;
                            Winner = playerTwo;
                        }
                    }
                    else
                    {
                        // player two has no cards so player one wins
                        roundWinner = PlayerTurn.PlayerOne;
                        Winner = playerOne;
                    }
                    break;
                default:
                    break;
            }
            if (Winner == null)
            {
                // check win
                roundWinner = DetermineHighest();
                if (roundWinner == PlayerTurn.None)
                {
                    roundWinner = PlayWar();
                }
            }
            // switch turn
            Turn = Turn == PlayerTurn.PlayerOne ? PlayerTurn.PlayerTwo : PlayerTurn.PlayerOne;
            return roundWinner;
        }

        /// <summary>
        /// Hand cards to the winning player after a round
        /// </summary>
        public void HandCardsToWinningPlayer()
        {
            if (Winner == null)
            {
                HandCardsToWinningPlayer(DetermineHighest());
            }
            else
            {
                if (Winner.Equals(playerOne))
                {
                    HandCardsToWinningPlayer(PlayerTurn.PlayerOne);
                }
                else
                {
                    HandCardsToWinningPlayer(PlayerTurn.PlayerTwo);
                }
            }
        }

        /// <summary>
        /// Play a card on the player's stack.
        /// </summary>
        /// <param name="player">The pleyer that plays the card</param>
        /// <param name="playerCards">The stack of that player in the game</param>
        /// <returns>True when the player was able to play, false when no cards on hand (player lost)</returns>
        private static bool PlayCard(Player player, Stack<Card> playerCards)
        {
            Card? card = player.PlayCard();
            if (card == null)
            {
                return false;
            }
            else
            {
                playerCards.Push(card);
                return true;
            }
        }

        /// <summary>
        /// Play war cards ont the player's stack
        /// </summary>
        /// <param name="player">The pleyer that plays the cards</param>
        /// <param name="playerCards">The stack of that player in the game</param>
        /// <returns>True when the player was able to play, false when no cards on hand (player lost)</returns>
        private static bool PlayWarCards(Player player, Stack<Card> playerCards)
        {
            Queue<Card> playedCards = player.PlayWarCards();
            bool returnValue = playedCards.Count == 4;
            foreach (Card card in playedCards)
            {
                playerCards.Push(card);
            }
            return returnValue;
        }

        /// <summary>
        /// Play war
        /// </summary>
        /// <returns>The winner of the game if a player was unable to play the card</returns>
        private PlayerTurn PlayWar()
        {
            PlayerTurn warWinner = PlayerTurn.None;
            bool noWinner = true;
            switch (Turn)
            {
                case PlayerTurn.PlayerOne:
                    noWinner = noWinner && PlayWarCards(playerOne, PlayerOnePlayedCards);
                    if (noWinner)
                    {
                        noWinner = noWinner && PlayWarCards(playerTwo, PlayerTwoPlayedCards);
                        if (!noWinner)
                        {
                            Winner = playerOne;
                            return PlayerTurn.PlayerOne;
                        }
                    }
                    else
                    {
                        Winner = playerTwo;
                        return PlayerTurn.PlayerTwo;
                    }
                    break;
                case PlayerTurn.PlayerTwo:
                    noWinner = noWinner && PlayWarCards(playerTwo, PlayerTwoPlayedCards);
                    if (noWinner)
                    {
                        noWinner = noWinner && PlayWarCards(playerOne, PlayerOnePlayedCards);
                        if (!noWinner)
                        {
                            Winner = playerTwo;
                            return PlayerTurn.PlayerTwo;
                        }
                    }
                    else
                    {
                        Winner = playerOne;
                        return PlayerTurn.PlayerOne;
                    }
                    break;
                default:
                    break;
            }

            if (Winner == null)
            {
                warWinner = DetermineHighest();
                if (warWinner == PlayerTurn.None)
                {
                    return PlayWar();
                }
            }
            return warWinner;
        }

        /// <summary>
        /// Actually end the game
        /// </summary>
        public void EndGame()
        {
            endGame = true;
            // if the game is set to end, reset all
            ReturnCardsFromPlayer(playerOne);
            ReturnCardsFromPlayer(playerTwo);
            GameStarted = false;
        }

        /// <summary>
        /// Get all the cards back from the player and put back in the deck
        /// </summary>
        /// <param name="player">The plater to get the cards for</param>
        private void ReturnCardsFromPlayer(Player player)
        {
            if (deck == null)
                throw new NullReferenceException();

            Card? card = player.PlayCard();
            while (card != null)
            {
                deck.ReceiveCard(card);
                card = player.PlayCard();
            }
        }

        /// <summary>
        /// Determine the winning player based on the last played card of each player
        /// </summary>
        /// <returns>0 for equal cardvalue, 1 for player 1, 2 for player 2</returns>
        private PlayerTurn DetermineHighest()
        {
            int playerOneValue = 0;
            int playerTwoValue = 0;

            if (PlayerOnePlayedCards.Count > 0)
            {
                playerOneValue = RankToValue(PlayerOnePlayedCards.Peek().Rank);
            }
            if (PlayerTwoPlayedCards.Count > 0)
            {
                playerTwoValue = RankToValue(PlayerTwoPlayedCards.Peek().Rank);
            }
            if (playerOneValue == playerTwoValue)
            {
                return PlayerTurn.None;
            }
            if (playerOneValue > playerTwoValue)
            {
                return PlayerTurn.PlayerOne;
            }
            else
            {
                return PlayerTurn.PlayerTwo;
            }
        }

        private void HandCardsToWinningPlayer(PlayerTurn winningPlayer)
        {
            Stack<Card> fromPlayerCards = new Stack<Card>();
            Player toPlayer = playerTwo;
            Stack<Card> toPlayerCards = new Stack<Card>();

            switch (winningPlayer)
            {
                case PlayerTurn.PlayerOne:
                    fromPlayerCards = PlayerTwoPlayedCards;
                    toPlayer = playerOne;
                    toPlayerCards = PlayerOnePlayedCards;
                    break;
                case PlayerTurn.PlayerTwo:
                    fromPlayerCards = PlayerOnePlayedCards;
                    toPlayer = playerTwo;
                    toPlayerCards = PlayerTwoPlayedCards;
                    break;
                default:
                    break;
            }
            StackToPlayer(fromPlayerCards, toPlayer);
            StackToPlayer(toPlayerCards, toPlayer);
        }

        /// <summary>
        /// Convert the rank of the card to a value for this game
        /// </summary>
        /// <param name="rank">The rank</param>
        /// <returns>The value</returns>
        private static int RankToValue(Rank rank)
        {
            // enum value is the rank only ace is 14 instead of 1
            return rank == Rank.Ace ? 14 : (int)rank;
        }

        /// <summary>
        /// Move a stack of cards to a player
        /// </summary>
        /// <param name="stack">The stack of cards (played cards)</param>
        /// <param name="destPlayer">The player that receives the cards on hand</param>
        private static void StackToPlayer(Stack<Card> stack, Player destPlayer)
        {
            while (stack.Count > 0)
            {
                destPlayer.ReceiveCard(stack.Pop());
            }
        }
    }
}
