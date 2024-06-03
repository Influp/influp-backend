using System.Drawing;

public class Adm : Usuario
{
    public Adm(int idUsuario, string username, string senha, string email, string nome, DateTime nascimento)
    : base(idUsuario, username, senha, email, nome, nascimento)
    {
        IdUsuario = idUsuario;
        Username = username;
        Senha = senha;
        Email = email;
        Nome = nome;
        Nascimento = nascimento;
    }
}