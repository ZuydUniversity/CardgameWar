namespace War
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play war!");

            Deck deck = new Deck(null);
            deck.ShuffleCards();
            
            var tst = deck.GetCard();
        }
    }
}