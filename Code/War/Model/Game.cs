using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Deck? Deck { get; set; }
        /// <summary>
        /// Player one
        /// </summary>
        private Player PlayerOne { get; set; }
        /// <summary>
        /// Cards played by player one. Stack because order should be contained (LIFO)
        /// </summary>
        private Stack<Card> PlayerOnePlayedCards { get; set; }
        /// <summary>
        /// Player two
        /// </summary>
        private Player PlayerTwo { get; set; }
        /// <summary>
        /// Cards played by player two. Stack because order should be contained (LIFO)
        /// </summary>
        private Stack<Card> PlayerTwoPlayedCards { get; set; }
        /// <summary>
        /// The winner of the game, null when game in progress/ no winner
        /// </summary>
        private Player? Winner { get; set; }

        /// <summary>
        /// Wich players turn? 1 or 2
        /// </summary>
        PlayerTurn turn;

        /// <summary>
        /// While endGame is false the game continues
        /// </summary>
        bool endGame;

        
        public Game(Player playerOne, Player playerTwo)
        {
            if (playerOne == null)
                throw new ArgumentNullException(nameof(playerOne));
            if (playerTwo == null)
                throw new ArgumentNullException(nameof(playerTwo));

            PlayerOne = playerOne;
            PlayerOne.CurrentGame = this;
            PlayerOnePlayedCards = new Stack<Card>();
            PlayerTwo = playerTwo;
            PlayerTwo.CurrentGame = this;
            PlayerTwoPlayedCards = new Stack<Card>();

            Winner = null;
            endGame = false;
            turn = PlayerTurn.None;

            Deck = new Deck(this);
            Deck.ShuffleCards();
        }

        /// <summary>
        /// Make everything ready to start the game
        /// See SD: Start game
        /// </summary>
        public void StartGame()
        {
            Winner = null;
            DetermineStartPlayer();
            DealCards();
            while (Winner == null && endGame == false)
            {
                PlayRound();
            }
            if (endGame)
            {
                EndGame();
            }
        }

        /// <summary>
        /// Deal all the cards of the deck
        /// </summary>
        private void DealCards()
        {
            if (Deck == null)
                throw new NullReferenceException(nameof(Deck));

            Card? card = Deck.GetCard();
            PlayerTurn startDealingPlayer = turn == PlayerTurn.PlayerOne ? PlayerTurn.PlayerTwo : PlayerTurn.PlayerOne;
            while (card != null)
            {
                switch (startDealingPlayer)
                {
                    case PlayerTurn.PlayerOne:
                        PlayerOne.ReceiveCard(card);
                        startDealingPlayer = PlayerTurn.PlayerTwo;
                        break;
                    case PlayerTurn.PlayerTwo:
                        PlayerTwo.ReceiveCard(card);
                        startDealingPlayer = PlayerTurn.PlayerOne;
                        break;
                    default:
                        break;
                }
                card = Deck.GetCard();
            }
        }

        /// <summary>
        /// Set the turn of the game to the starting player randomly
        /// </summary>
        private void DetermineStartPlayer()
        {
            Random r = new Random();
            turn = (PlayerTurn)(r.Next(1) + 1);
        }

        /// <summary>
        /// Play a round
        /// </summary>
        public void PlayRound()
        {
            // play a round
            // stop as soon there is a winner
            bool noGameWinner = true;
            PlayerTurn roundWinner = PlayerTurn.None;
            switch (turn)
            {
                case PlayerTurn.PlayerOne:
                    noGameWinner = noGameWinner && PlayCard(PlayerOne, PlayerOnePlayedCards);
                    if (noGameWinner)
                    {
                        noGameWinner = noGameWinner && PlayCard(PlayerTwo, PlayerTwoPlayedCards);
                        if (!noGameWinner)
                        {
                            roundWinner = PlayerTurn.PlayerOne;
                            Winner = PlayerOne;
                        }
                    }
                    else
                    {
                        // player one has no cards so player two wins
                        roundWinner = PlayerTurn.PlayerTwo;
                        Winner = PlayerTwo;
                    }
                    break;
                case PlayerTurn.PlayerTwo:
                    noGameWinner = noGameWinner && PlayCard(PlayerTwo, PlayerTwoPlayedCards);
                    if (noGameWinner)
                    {
                        noGameWinner = noGameWinner && PlayCard(PlayerOne, PlayerOnePlayedCards);
                        if (!noGameWinner)
                        {
                            roundWinner = PlayerTurn.PlayerTwo;
                            Winner = PlayerTwo;
                        }
                    }
                    else
                    {
                        // player two has no cards so player one wins
                        roundWinner = PlayerTurn.PlayerOne;
                        Winner = PlayerOne;
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
                    // todo hier verder
                    roundWinner = PlayWar();
                }
            }
            HandCardsToWinningPlayer(roundWinner);
        }

        /// <summary>
        /// Play a card on the player's stack.
        /// </summary>
        /// <param name="player">The pleyer that plays the card</param>
        /// <param name="playerCards">The stack of that player in the game</param>
        /// <returns>True when the player was able to play, false when no cards on hand (player lost)</returns>
        private bool PlayCard(Player player, Stack<Card> playerCards)
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
        private bool PlayWarCards(Player player, Stack<Card> playerCards)
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
            switch (turn)
            {
                case PlayerTurn.PlayerOne:
                    noWinner = noWinner && PlayWarCards(PlayerOne, PlayerOnePlayedCards);
                    if (noWinner)
                    {
                        noWinner = noWinner && PlayWarCards(PlayerTwo, PlayerTwoPlayedCards);
                        if (!noWinner)
                        {
                            Winner = PlayerOne;
                            return PlayerTurn.PlayerOne;
                        }
                    }
                    else
                    {
                        Winner = PlayerTwo;
                        return PlayerTurn.PlayerTwo;
                    }
                    break;
                case PlayerTurn.PlayerTwo:
                    noWinner = noWinner && PlayWarCards(PlayerTwo, PlayerTwoPlayedCards);
                    if (noWinner)
                    {
                        noWinner = noWinner && PlayWarCards(PlayerOne, PlayerOnePlayedCards);
                        if (!noWinner)
                        {
                            Winner = PlayerTwo;
                            return PlayerTurn.PlayerTwo;
                        }
                    }
                    else
                    {
                        Winner = PlayerOne;
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
        /// Sets the running game to end
        /// </summary>
        public void SetEndGame()
        {
            endGame = false;
        }

        /// <summary>
        /// Actually end the game
        /// </summary>
        private void EndGame()
        {
            // if the game is set to end, reset all
            ReturnCardsFromPlayer(PlayerOne);
            ReturnCardsFromPlayer(PlayerTwo);
        }

        /// <summary>
        /// Get all the cards back from the player and put back in the deck
        /// </summary>
        /// <param name="player">The plater to get the cards for</param>
        private void ReturnCardsFromPlayer(Player player)
        {
            Card? card = player.PlayCard();
            while (card != null)
            {
                Deck.ReceiveCard(card);
                card = player.PlayCard();
            }
        }

        /// <summary>
        /// Determine the winning player based on the last played card of each player
        /// </summary>
        /// <returns>0 for equal cardvalue, 1 for player 1, 2 for player 2</returns>
        private PlayerTurn DetermineHighest()
        {
            // todo maken
            return PlayerTurn.PlayerOne;
        }

        private void HandCardsToWinningPlayer(PlayerTurn winningPlayer)
        {
            Player fromPlayer = null;
            Stack<Card> fromPlayerCards = new Stack<Card>();
            Player toPlayer = null;
            Stack<Card> toPlayerCards = new Stack<Card>();

            switch (winningPlayer)
            {
                case PlayerTurn.PlayerOne:
                    fromPlayer = PlayerTwo;
                    fromPlayerCards = PlayerTwoPlayedCards;
                    toPlayer = PlayerOne;
                    toPlayerCards = PlayerOnePlayedCards;
                    break;
                case PlayerTurn.PlayerTwo:
                    fromPlayer = PlayerOne;
                    fromPlayerCards = PlayerOnePlayedCards;
                    toPlayer = PlayerTwo;
                    toPlayerCards = PlayerTwoPlayedCards;
                    break;
                default:
                    break;
            }

            StackToPlayer(fromPlayerCards, toPlayer);
            StackToPlayer(toPlayerCards, toPlayer);
        }

        private static void StackToPlayer(Stack<Card> stack, Player? destPlayer)
        {
            while (stack.Count > 0)
            {
                destPlayer.ReceiveCard(stack.Pop());
            }
        }
    }
}
