using System.Data.SqlClient;
using Advanced_War.Domain.GameTheory.Interfaces;

namespace Advanced_War.Domain.GameTheory;

public class SqlPlayerRepository: IPlayerRepository
{
    private readonly string connectionString;

    public SqlPlayerRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }
    
    public void Create(Player player)
    {
        // checks
        if (player == null) throw new ArgumentNullException(nameof(player));
        if (player.Id > 0)
        {
            throw new Exception("Player already has a player number! Cannot create an existing player.");
        }

        // add player
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            var sql = "insert into Player(PlayerName, Wins, Games) VALUES (@name, @wins, @games)";
            connection.Open();

            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", player.Name);
                command.Parameters.AddWithValue("@wins", player.Wins);
                command.Parameters.AddWithValue("@games", player.Games);
                command.ExecuteNonQuery();

                command.CommandText = "SELECT CAST(@@Identity as INT);";
                var addId = (int)command.ExecuteScalar();
                player.Id = addId;
            }
        }
    }

    public List<Player> Get()
    {
        List<Player> players = new List<Player>();
        using (SqlConnection connection = new SqlConnection())
        {
            using (SqlCommand command = new SqlCommand())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select playernumber, playername, wins, games from player";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader == null) return players;
                    
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
        }
        return players;
    }

    public List<Player> GetTopPlayers(int top)
    {
        List<Player> players = new List<Player>();
        using (SqlConnection connection = new SqlConnection())
        {
            using (SqlCommand command = new SqlCommand())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select top {top} playernumber, playername, wins, games from player order by wins desc";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader == null) return players;
                    
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
        }
        return players;
    }

    public Player? Get(int playerNumber)
    {
        using (SqlConnection connection = new SqlConnection())
        {
            using (SqlCommand command = new SqlCommand())
            {
                connection.ConnectionString = connectionString;
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
            }
        }
        return null;
    }

    public void Update(Player player)
    {
        if (player == null) throw new ArgumentNullException(nameof(player));
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = $"update player set playerName = @name, wins = @wins, games = @games where playernumber = @playernumber;";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", player.Name);
                command.Parameters.AddWithValue("@wins", player.Wins);
                command.Parameters.AddWithValue("@games", player.Games);
                command.Parameters.AddWithValue("@playernumber", player.Id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int playerNumber)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "delete from player where playernumber = @playerNumber";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@playerNumber", playerNumber);
                command.ExecuteNonQuery();
            }
        }
    }
}