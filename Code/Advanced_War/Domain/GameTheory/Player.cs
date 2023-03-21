﻿using Advanced_War.Domain.WarDeck;

namespace Advanced_War.Domain.GameTheory;

public class Player
{
    public int Id { get; set; }
    public string Name { get; init; }
    public int Wins { get; private set; }
    public int Games { get; private set; }
    private Queue<Card> Hand { get; set; }

    public Player(string name)
    {
        Name = name;
    }
    
    public Player(int playerNumber, string playerName, int wins, int games) : this(playerName)
    {
        Id = playerNumber;
        Wins = wins;
        Games = games;
        Hand = new Queue<Card>();
    }

    public void AddPlayedGame(bool victory)
    {
        Games++;
        Wins = victory ? Wins + 1 : Wins;
    }
    
    public void AddCardToHand(Card card)
    {
        if (card == null)
        {
            throw new ArgumentNullException(nameof(card));
        }

        Hand.Enqueue(card);
    }

    public Card PlayCard()
    {
        if (Hand.Count == 0)
        {
            throw new InvalidOperationException("Player has no cards left to play.");
        }

        return Hand.Dequeue();
    }

    public int CardCount => Hand.Count;
}