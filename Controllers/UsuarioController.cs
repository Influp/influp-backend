using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }




    [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioConcreto usuario)
    {

        if (_usuarioService.BuscarUsuarioLogin(usuario.Username, usuario.Senha))
        {
            return Ok(new { Token = "fake-jwt-token" });
        }
        return Unauthorized();
    }
}