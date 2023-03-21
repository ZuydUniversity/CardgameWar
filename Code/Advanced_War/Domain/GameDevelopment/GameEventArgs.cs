namespace Advanced_War.Domain.GameDevelopment;

public class GameEventArgs: System.EventArgs
{
    public string Message { get; }

    public GameEventArgs(string message)
    {
        Message = message;
    }
}