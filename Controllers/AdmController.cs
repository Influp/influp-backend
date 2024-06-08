using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class AdmController : ControllerBase
{
    private readonly AdmService _admService;

    public AdmController(AdmService admService)
    {
        _admService = admService;
    }

    [HttpGet("buscarInfluenciadorPorId")]
    public IActionResult ListarInfluenciadorPorId(int id)
    {

        InfluenciadorLeituraDTO influenciador = _admService.ListarInfluenciadorPorId(id);


        if (influenciador == null)
        {
            return NotFound(new { message = "Influenciador não encontrado." });
        }

        return Ok(influenciador);
    }

    [HttpGet("buscarInfluenciadores")]
    public IActionResult ListarTodosInfluenciadores()
    {

        var influenciadores = _admService.ListarTodosInfluenciadores();

        if (influenciadores.Count <= 0)
        {
            return NotFound(new { message = "Nenhum influenciador encontrado." });
        }

        return Ok(influenciadores);
    }

    [HttpGet("buscarInfluenciadoresPorNome")]
    public IActionResult ListarInfluenciadorPorNome(string nome)
    {
        var influenciadores = _admService.ListarInfluenciadoresPorNome(nome);

        if (influenciadores.Count <= 0)
        {
            return NotFound(new { message = "Nenhum influenciador com este nome não encontrado." });
        }

        return Ok(influenciadores);
    }

    [HttpPost("cadastrarInfluenciador")]
    public IActionResult CadastrarInfluenciador([FromBody] InfluenciadorEscritaDTO influenciador)
    {

        int fkUsuario = _admService.CadastrarUsuario(influenciador);
        _admService.CadastrarInfluenciador(influenciador, fkUsuario);


        return Created("", influenciador);
    }

    [HttpPut("atualizarInfluenciador")]
    public IActionResult AtualizarInfluenciador([FromBody] InfluenciadorEscritaDTO influenciador, int idInfluenciador)
    {

        var influenciadorDTO = _admService.ListarInfluenciadorPorId(idInfluenciador);
        if (influenciadorDTO == null)
        {
            return NotFound(new { message = "Influenciador não encontrado." });
        }

        _admService.AtualizarInfluenciador(influenciador, idInfluenciador);
        _admService.AtualizarUsuario(influenciador, influenciadorDTO.IdUsuario);

        return NoContent();
    }

    [HttpDelete("deletarInfluenciador")]
    public IActionResult DeletarInfluenciador(int idInfluenciador)
    {

        var influenciadorDTO = _admService.ListarInfluenciadorPorId(idInfluenciador);

        if (influenciadorDTO == null)
        {
            return NotFound(new { message = "Influenciador não encontrado." });
        }

        _admService.DeletarInfluenciador(idInfluenciador);

        return NoContent();
    }

}