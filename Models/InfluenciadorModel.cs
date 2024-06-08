using System.Drawing;

public class Influenciador : Usuario
{  
    public int IdInfluenciador { get; set; }
    public int Inscritos { get; set; }
    public string Handle { get; set; }
    public string Categoria { get; set; }
    public Influenciador(){}
    public Influenciador(int idUsuario, string username, string senha, string email, string nome, DateTime nascimento,
     int inscritos, string handle, string categoria)
    : base(idUsuario, username, senha, email, nome, nascimento)
    {
        IdUsuario = idUsuario;
        Username = username;
        Senha = senha;
        Email = email;
        Nome = nome;
        Nascimento = nascimento;
        Inscritos = inscritos;
        Handle = handle;
        Categoria = categoria;
    }
}