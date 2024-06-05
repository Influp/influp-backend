using System.Data;
using Dapper;

public class UsuarioService
{
    private readonly IDbConnection _connection;

    public UsuarioService(IDbConnection connection)
    {
        _connection = connection;
    }
    public bool BuscarUsuarioLogin(string userName, string senha)
    {
        string query = "SELECT COUNT(*) FROM USUARIO WHERE userName = '" + userName + "' AND senha = '" + senha + "' ";

        int count = _connection.QuerySingle<int>(query, new { UserName = userName, Senha = senha });

        return count > 0;
    }

}
