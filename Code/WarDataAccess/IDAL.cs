
using WarDataAccess;

namespace War.DataAccess
{
    /// <summary>
    /// Interface for data access layer implementation
    /// </summary>
    public interface IDAL
    {
        public void CreatePlayerData(IPlayerData player);

        public List<T> ReadPlayersData<T>();

        public List<T> ReadHighscoreData<T>();

        public T? ReadPlayerData<T>(int playerNumber);

        public void UpdatePlayerData(IPlayerData player);

        public void DeletePlayerData(int playerNumber);
    }
}
