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
        string query = @"SELECT *
        FROM Usuario u
        INNER JOIN Influenciador i ON u.IdUsuario = i.fkUsuario;";

        var influenciadores = _connection.Query<Influenciador>(query).ToList();
        return influenciadores;
    }

    public InfluenciadorLeituraDTO ListarInfluenciadorPorId(int id)
    {
        string query = @"SELECT *
        FROM Usuario u
        INNER JOIN Influenciador i ON u.IdUsuario = i.fkUsuario
        WHERE idInfluenciador = " + id + ";";

        InfluenciadorLeituraDTO influenciador = _connection.QueryFirstOrDefault<InfluenciadorLeituraDTO>(query, new { Id = id });
        return influenciador;
    }

    public List<Influenciador> ListarInfluenciadoresPorNome(string nome)
    {
        string query = @"SELECT *
            FROM Usuario u
            INNER JOIN Influenciador i ON u.IdUsuario = i.fkUsuario
            WHERE u.Nome LIKE '%" + nome + "%'";

        var influenciadores = _connection.Query<Influenciador>(query).ToList();
        return influenciadores;
    }

    public void CadastrarInfluenciador(InfluenciadorEscritaDTO influenciador, int fkUsuario)
    {

        if (fkUsuario > 0)
        {
            string insertQuery = $@"INSERT INTO influenciador ( inscritos, handle, categoria, fkUsuario) 
                           VALUES ('{influenciador.Inscritos}', '{influenciador.Handle}', '{influenciador.Categoria}', '{fkUsuario}')";

            _connection.Execute(insertQuery, influenciador);
        }
        Console.WriteLine("Ocorreu um erro no cadastro de usuário");

    }

    public int CadastrarUsuario(InfluenciadorEscritaDTO influenciador)
    {
        string query = $@"
            INSERT INTO Usuario (Username, Senha, Email, Nome, Nascimento)
            VALUES ('{influenciador.Username}', '{influenciador.Senha}', '{influenciador.Email}',
             '{influenciador.Nome}', '{influenciador.Nascimento.ToString("yyyy-MM-dd HH:mm:ss")}');
            SELECT LAST_INSERT_ID();"; // Retorna o ID gerado automaticamente

        int idUsuario = _connection.QuerySingle<int>(query, influenciador);
        return idUsuario;
    }

    public void AtualizarInfluenciador(InfluenciadorEscritaDTO influenciador, int idInfluenciador)
    {
        string query = $@"
            UPDATE influenciador 
            SET inscritos = {influenciador.Inscritos},
            handle = '{influenciador.Handle}',
            categoria = '{influenciador.Categoria}'
            WHERE idInfluenciador = {idInfluenciador};
            ";

        Console.WriteLine("SQL: " + query);

        _connection.Execute(query, new
        {
            Handle = influenciador.Handle,
            Categoria = influenciador.Categoria,
            Inscritos = influenciador.Inscritos,
        });
    }

    public void AtualizarUsuario(InfluenciadorEscritaDTO influenciador, int idUsuario)
    {
        string query = $@"
            UPDATE Usuario 
            SET userName = '{influenciador.Username}',
            senha = '{influenciador.Senha}',
            email = '{influenciador.Email}',
            nome = '{influenciador.Nome}',
            nascimento = '{influenciador.Nascimento.ToString("yyyy-MM-dd HH:mm:ss")}'
            WHERE idUsuario = {idUsuario};
            ";

        _connection.Execute(query, new
        {
            Username = influenciador.Username,
            Senha = influenciador.Senha,
            Email = influenciador.Email,
            Nome = influenciador.Nome,
            Nascimento = influenciador.Nascimento,
        });
    }

    public void DeletarUsuario(int id)
    {
        string query = $@"
            DELETE FROM usuario WHERE idUsuario = {id};";

        _connection.Execute(query);
    }
    public void DeletarInfluenciador(int id)
    {
        string query = $@"
            DELETE FROM influenciador WHERE idInfluenciador = {id};";

        _connection.Execute(query);
    }
}
