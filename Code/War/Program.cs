namespace War
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Let's play war!");

            Player one = new Player("Rob");
            Player two = new Player("Rob");

            Game game = new Game(one, two);

            game.StartGame();


        }
    }
}