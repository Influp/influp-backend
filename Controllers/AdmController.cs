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


    [HttpGet("buscarUsuarios")]
    public List<Influenciador> ListarTodosInfluenciadores(){
        
        var influenciadores = _admService.ListarTodosInfluenciadores();
        
        return influenciadores;
    }

}