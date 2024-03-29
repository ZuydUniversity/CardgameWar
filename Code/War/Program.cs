﻿using War.Model;

namespace War
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Let's play war!");

            Player? one = Player.ReadPlayerData(1);
            Player? two = Player.ReadPlayerData(2);

            if (one != null && two != null)
            {
                Game game = new Game(one, two);
                game.StartGame();
                bool ended = false;
                while (game.Winner == null && !ended)
                {
                    try
                    {
                        Console.WriteLine($"Round won by {game.PlayRound()}. Cards on hand p1 {one.CardCount} p2 {two.CardCount}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        ended = true;
                    }
                    //game.EndGame();
                }
                Console.WriteLine($"Game won by {game.Winner?.PlayerName}");


                game.StartGame();
            }
        }
    }
}