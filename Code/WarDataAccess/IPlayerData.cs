using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarDataAccess
{
    /// <summary>
    /// Interface for Player Data Access
    /// </summary>
    public interface IPlayerData
    {
        public int PlayerNumber { get; set; }
        public string PlayerName { get; }
        public int Wins { get; }
        public int Games { get; }
    }
}
