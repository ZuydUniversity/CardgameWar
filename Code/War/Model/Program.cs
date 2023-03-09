namespace War.Model
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Let's play war!");

            Player one = new Player("Rob");
            Player two = new Player("Piet");

            Game game = new Game(one, two);

            game.StartGame();

            while (game.Winner == null) 
            {
                Console.WriteLine($"Round won by {game.PlayRound()}. Cards on hand p1 {one.CardCount} p2 {two.CardCount}");
            }
            Console.WriteLine($"Game won by {game.Winner.PlayerName}");

        }
    }
}