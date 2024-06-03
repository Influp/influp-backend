using System.Data;
using MySql.Data.MySqlClient;

public class Database
{
    private readonly string _connectionString;

    public Database(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Connection => new MySqlConnection(_connectionString);
}
