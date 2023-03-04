using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
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
        private Stack<Card> PlayerOneCards { get; set; }
        /// <summary>
        /// Player two
        /// </summary>
        private Player PlayerTwo { get; set; }
        /// <summary>
        /// Cards played by player two. Stack because order should be contained (LIFO)
        /// </summary>
        private Stack<Card> PlayerTwoCards { get; set; }
        /// <summary>
        /// The winner of the game, null when game in progress/ no winner
        /// </summary>
        private Player? Winner { get; set; }

        /// <summary>
        /// Wich players turn? 1 or 2
        /// </summary>
        PlayerTurn turn = PlayerTurn.None;
        
        /// <summary>
        /// While endGame is false the game continues
        /// </summary>
        bool endGame = false;

        public Game(Player playerOne, Player playerTwo)
        {
            if (playerOne == null)
                throw new ArgumentNullException(nameof(playerOne));
            if (playerTwo == null)
                throw new ArgumentNullException(nameof(playerTwo));
            
            PlayerOne = playerOne;
            PlayerOne.CurrentGame = this;
            PlayerOneCards = new Stack<Card>();
            PlayerTwo = playerTwo;
            PlayerTwo.CurrentGame = this;
            PlayerTwoCards = new Stack<Card>();

            Winner = null;

        }

        /// <summary>
        /// Make everything ready to start the game
        /// See SD: Start game
        /// </summary>
        public void StartGame()
        {
            //init
            Deck = new Deck(this);
            Deck.ShuffleCards();

            //deal cards
            this.DealCards();
        }

        /// <summary>
        /// Deal the cards of the deck
        /// </summary>
        private void DealCards()
        {
            if (Deck == null)
                throw new NullReferenceException(nameof(Deck));

            Card? card = Deck.GetCard();
            turn = PlayerTurn.PlayerOne;
            while (card != null)
            {
                switch (turn)
                {
                    case PlayerTurn.PlayerOne:
                        PlayerOne.ReceiveCard(card);
                        turn = PlayerTurn.PlayerTwo;
                        break;
                    case PlayerTurn.PlayerTwo:
                        PlayerTwo.ReceiveCard(card);
                        turn = PlayerTurn.PlayerOne;
                        break;
                    default:
                        break;
                }
                card = Deck.GetCard();
            }
            turn = PlayerTurn.None;
        }

        /// <summary>
        /// Set the turn of the game to the starting player randomly
        /// </summary>
        private void DetermineStartPlayer()
        {
            Random r = new Random();
            turn = (PlayerTurn)(r.Next(1) + 1);
        }

        public void PlayRound()
        {
            if (endGame)
            {
                // if the game is set to end, reset all
                PlayerOne.ResetCardsOnHand();
                PlayerTwo.ResetCardsOnHand();
                Deck = null;
                PlayerOneCards = null;
                PlayerTwoCards = null;
            }
            else
            {
                // play a round

                // todo hier gebleven
                switch (turn)
                {
                    case PlayerTurn.PlayerOne:
                        PlayerOne.PlayCard();
                        PlayerTwo.PlayCard();
                        break;
                    case PlayerTurn.PlayerTwo:
                        PlayerTwo.PlayCard();
                        PlayerOne.PlayCard();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the running game to end
        /// </summary>
        public void EndGame()
        {
            endGame = false;
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
                    fromPlayer = PlayerOne;
                    fromPlayerCards = PlayerOneCards;
                    toPlayer = PlayerTwo;
                    toPlayerCards = PlayerTwoCards;
                    break;
                case PlayerTurn.PlayerTwo:
                    fromPlayer = PlayerTwo;
                    fromPlayerCards = PlayerTwoCards;
                    toPlayer = PlayerOne;
                    toPlayerCards = PlayerOneCards;
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
