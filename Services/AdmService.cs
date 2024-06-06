using System.Data;
using Dapper;

public class AdmService
{
    private readonly IDbConnection _connection;

    public AdmService(IDbConnection connection)
    {
        _connection = connection;
    }
    public List<InfluenciadorDTO> ListarTodosInfluenciadores()
    {
        string query = @"SELECT u.IdUsuario, u.Username, u.Senha, u.Email, u.Nome, u.Nascimento,
               i.Inscritos, i.Handle, i.Categoria
        FROM Usuario u
        INNER JOIN Influenciador i ON u.IdUsuario = i.fkUsuario;";

        var influenciadores = _connection.Query<InfluenciadorDTO>(query).ToList();
        return influenciadores;
    }

    public List<InfluenciadorDTO> ListarInfluenciadoresPorNome(String nome)
    {
        string query = @"SELECT u.IdUsuario, u.Username, u.Senha, u.Email, u.Nome, u.Nascimento,
            i.Inscritos, i.Handle, i.Categoria
            FROM Usuario u
            INNER JOIN Influenciador i ON u.IdUsuario = i.fkUsuario
            WHERE u.Nome LIKE '%" + nome + "%'";

        var influenciadores = _connection.Query<InfluenciadorDTO>(query).ToList();
        return influenciadores;
    }

    public void CadastrarInfluenciador(InfluenciadorDTO influenciadorDTO)
    {
        int fkUsuario = CadastrarUsuario(influenciadorDTO);

        if (fkUsuario > 0)
        {
            string insertQuery = $@"INSERT INTO influenciador ( inscritos, handle, categoria, fkUsuario) 
                           VALUES ('{influenciadorDTO.Inscritos}', '{influenciadorDTO.Handle}', '{influenciadorDTO.Categoria}', '{fkUsuario}')";

            _connection.Execute(insertQuery, influenciadorDTO);
        }
        Console.WriteLine("Ocorreu um erro no cadastro de usuário");

    }

    public int CadastrarUsuario(InfluenciadorDTO influenciadorDTO)
    {
        // Insere o usuário na tabela de usuários
        string insertUsuarioQuery = $@"
            INSERT INTO Usuario (Username, Senha, Email, Nome, Nascimento)
            VALUES ('{influenciadorDTO.Username}', '{influenciadorDTO.Senha}', '{influenciadorDTO.Email}',
             '{influenciadorDTO.Nome}', '{influenciadorDTO.Nascimento.ToString("yyyy-MM-dd HH:mm:ss")}');
            SELECT LAST_INSERT_ID();"; // Retorna o ID gerado automaticamente

        int idUsuario = _connection.QuerySingle<int>(insertUsuarioQuery, influenciadorDTO);
        return idUsuario;
    }
}
