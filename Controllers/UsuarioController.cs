using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public AuthController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }




    [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioConcreto usuario)
    {

        if (_usuarioService.BuscaUsuarioLogin(usuario.Username, usuario.Senha))
        {
            return Ok(new { Token = "fake-jwt-token" });
        }
        return Unauthorized();
    }
}