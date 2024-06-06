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


    [HttpGet("buscarInfluenciadores")]
    public List<InfluenciadorDTO> ListarTodosInfluenciadores(){
        
        var influenciadores = _admService.ListarTodosInfluenciadores();
        
        return influenciadores;
    }

    [HttpGet("buscarInfluenciadoresPorNome")]
    public List<InfluenciadorDTO> ListarInfluenciadorPorNome (String nome){
        var influenciadores = _admService.ListarInfluenciadoresPorNome(nome);

        return influenciadores;
    }

    [HttpPost("cadastrarInfluenciador")]
    public IActionResult CadastrarInfluenciador([FromBody] InfluenciadorDTO influenciador)
    {

        _admService.CadastrarInfluenciador(influenciador);

        return Created("", influenciador);
    }

}