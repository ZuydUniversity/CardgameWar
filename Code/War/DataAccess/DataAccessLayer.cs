using System.Data.SqlClient;
using War.Model;

namespace War.DataAccess
{
    public class DataAccessLayer : IDAL
    {
        /// <summary>
        /// Servername
        /// </summary>
        private readonly string serverName;
        /// <summary>
        /// Databasename
        /// </summary>
        private readonly string databaseName;
        /// <summary>
        /// The generated connection string
        /// </summary>
        /// <returns></returns>
        private string ConnectionString() => $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

        /// <summary>
        /// default constructor
        /// </summary>
        public DataAccessLayer()
        {
            serverName = ".";
            databaseName = "CardGameExample";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataAccessLayer(string serverName, string databaseName)
        {
            this.serverName = serverName ?? throw new ArgumentNullException(nameof(serverName));
            this.databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        }

        /// <summary>
        /// Create a player in the database
        /// </summary>
        /// <param name="player">The player to create</param>
        /// <returns>The player including the playernumber</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreatePlayerData(Player player)
        {
            // checks
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.PlayerNumber > 0)
            {
                throw new Exception("Player already has a player number! Cannot create an existing player.");
            }

            // add player
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                string sql = "insert into Player (PlayerName, Wins, Games, PlayerType) VALUES (@name, @wins, @games, @playertype)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", player.PlayerName);
                    command.Parameters.AddWithValue("@wins", player.Wins);
                    command.Parameters.AddWithValue("@games", player.Games);
                    command.Parameters.AddWithValue("@playertype", player.ToString());
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT CAST(@@Identity as INT);";
                    int addId = (int)command.ExecuteScalar();
                    player.PlayerNumber = addId;
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Read the player with the unique playernumber
        /// </summary>
        /// <param name="playerNumber">The number of the player</param>
        /// <returns>The player</returns>
        public Player? ReadPlayerData(int playerNumber)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = ConnectionString();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"select playernumber, playername, wins, games from player where playernumber = @playerNumber";
                    command.Parameters.AddWithValue("@playerNumber", playerNumber);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // will only iterate once but will prevent error when no results
                        while (reader.Read())
                        {
                            // prevent null reference warnings
                            var idString = reader[0].ToString() ?? "0";
                            var nameString = reader[1].ToString() ?? string.Empty;
                            var winsString = reader[2].ToString() ?? "0";
                            var gamesString = reader[3].ToString() ?? "0";

                            return new Player(
                                Int32.Parse(idString),
                                nameString,
                                Int32.Parse(winsString),
                                Int32.Parse(gamesString));
                        }
                    }
                    connection.Close();
                }
            }
            return null;
        }

        /// <summary>
        /// Read all players
        /// </summary>
        /// <returns>List with all players</returns>
        public List<Player> ReadPlayersData()
        {
            List<Player> players = new List<Player>();
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = ConnectionString();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select playernumber, playername, wins, games from player";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                            while (reader.Read())
                            {
                                // prevent null reference warnings
                                var idString = reader[0].ToString() ?? "0";
                                var nameString = reader[1].ToString() ?? string.Empty;
                                var winsString = reader[2].ToString() ?? "0";
                                var gamesString = reader[3].ToString() ?? "0";

                                players.Add(new Player(
                                    Int32.Parse(idString), nameString, Int32.Parse(winsString), Int32.Parse(gamesString))
                                );

                            }
                    }
                    connection.Close();
                }
            }
            return players;
        }


        /// <summary>
        /// Update the player in the datalayer
        /// </summary>
        /// <param name="player">The player to update</param>
        /// <exception cref="ArgumentNullException">The exception thrown if there is no player</exception>
        public void UpdatePlayerData(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.PlayerNumber == 0)
            {
                // create player instead of update
                player.CreatePlayerData();
            }
            else
            {
                // player exists so update
                using (SqlConnection connection = new SqlConnection(ConnectionString()))
                {
                    connection.Open();
                    string sql = $"update player set playerName = @name, wins = @wins, games = @games where playernumber = @playernumber;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", player.PlayerName);
                        command.Parameters.AddWithValue("@wins", player.Wins);
                        command.Parameters.AddWithValue("@games", player.Games);
                        command.Parameters.AddWithValue("@playernumber", player.PlayerNumber);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Delete a player
        /// </summary>
        /// <param name="playerNumber">The number of the player to delete</param>
        public void DeletePlayerData(int playerNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                connection.Open();
                string sql = "delete from player where playernumber = @playerNumber";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@playerNumber", playerNumber);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<Player> ReadHighscoreData()
        {
            List<Player> players = new List<Player>();
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = ConnectionString();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select top 3 playernumber, playername, wins, games from player order by wins desc";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                // prevent null reference warnings
                                var idString = reader[0].ToString() ?? "0";
                                var nameString = reader[1].ToString() ?? string.Empty;
                                var winsString = reader[2].ToString() ?? "0";
                                var gamesString = reader[3].ToString() ?? "0";

                                players.Add(new Player(
                                    Int32.Parse(idString), nameString, Int32.Parse(winsString), Int32.Parse(gamesString))
                                );

                            }
                        }
                    }
                    connection.Close();
                }
            }
            return players;
        }
    }
}
