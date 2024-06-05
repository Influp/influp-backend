using System.ComponentModel.DataAnnotations;
public abstract class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    public string Username { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public Usuario() { }
    public Usuario(int idUsuario, string username, string senha, string email,string nome, DateTime nascimento)
    {
        IdUsuario = idUsuario;
        Username = username;
        Senha = senha;
        Email = email;
        Nome = nome;
        Nascimento = nascimento;
    }

}