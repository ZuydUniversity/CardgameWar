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
    public interface iDAL
    {
            
        public void CreatePlayer(Player player);
        
        public List<Player> ReadPlayers();

        public Player ReadPlayer(int playerNumber);

        public void UpdatePlayer(Player player);

        public void DeletePlayer(int playerNumber);
    }
}
