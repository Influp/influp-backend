using System.Data;
using Dapper;

public class AdmService
{
    private readonly IDbConnection _connection;

    public AdmService(IDbConnection connection)
    {
        _connection = connection;
    }
    public List<Influenciador> ListarTodosInfluenciadores()
    {
        string query = @"SELECT u.IdUsuario, u.Username, u.Senha, u.Email, u.Nome, u.Nascimento,
               i.Inscritos, i.Handle, i.Categoria
        FROM Usuario u
        INNER JOIN Influenciador i ON u.IdUsuario = i.fkUsuario;";

        var influenciadores = _connection.Query<Influenciador>(query).ToList();
        return influenciadores;
    }

    // public void CreateUser(string userName, string senha, string email, string nome, DateTime nascimento)
    // {
    //     string insertQuery = $@"INSERT INTO usuario (userName, senha, email, nome, nascimento) 
    //                        VALUES ('{userName}', '{senha}', '{email}', '{nome}', '{nascimento.ToString("yyyy-MM-dd HH:mm:ss")}')";
        
    //     _connection.Execute(insertQuery, new { UserName = userName, Senha = senha, Email = email, Nome = nome, Nascimento = nascimento });
    // }
}
