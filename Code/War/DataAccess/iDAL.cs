using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Model;

namespace War.DataAccess
{
    /// <summary>
    /// Interface for data access layer implementation
    /// </summary>
    public interface IDAL
    {
        public void CreatePlayerData(Player player);
        
        public List<Player> ReadPlayersData();

        public Player? ReadPlayerData(int playerNumber);

        public void UpdatePlayerData(Player player);

        public void DeletePlayerData(int playerNumber);
    }
}
