using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;


namespace Influp
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=localhost;Database=influp;Uid=root;Pwd=admin;";

            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    Console.WriteLine("Conexão bem sucedida!");

                    // Exemplo de consulta para listar usuários
                    List<UsuarioConcreto> usuarios = db.Query<UsuarioConcreto>("SELECT * FROM usuario").ToList();
                    foreach (var usuario in usuarios)
                    {
                        Console.WriteLine($"ID: {usuario.IdUsuario}, Nome: {usuario.Nome}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao conectar: {ex.Message}");
                }
            }


            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}