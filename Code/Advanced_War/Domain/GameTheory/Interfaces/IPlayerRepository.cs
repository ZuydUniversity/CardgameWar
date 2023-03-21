namespace Advanced_War.Domain.GameTheory.Interfaces;

public interface IPlayerRepository
{
    void Create(Player player);

    List<Player> Get();

    List<Player> GetTopPlayers(int top);

    Player? Get(int playerNumber);

    void Update(Player player);

    void Delete(int playerNumber);
}