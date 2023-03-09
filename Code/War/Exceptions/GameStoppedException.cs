namespace War.Exceptions
{
    /// <summary>
    /// Exception to notify that the game has stopped for some reason
    /// </summary>
    public class GameStoppedException : Exception
    {
        public GameStoppedException(string message) : base(message)
        {
        }
    }
}
