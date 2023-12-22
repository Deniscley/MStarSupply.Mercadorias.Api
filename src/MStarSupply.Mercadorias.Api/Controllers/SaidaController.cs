using Microsoft.AspNetCore.Mvc;
using MStarSupply.Application.Services;
using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Controllers
{
    [Route("api/saida")]
    [ApiController]
    public class SaidaController : Controller
    {
        private readonly ISaidaAppService _saidaAppService;
        public SaidaController(
            ISaidaAppService saidaAppService
        )
        {
            _saidaAppService = saidaAppService;
        }

        [HttpGet("obter-itens-pagina")]
        public async Task<IActionResult> obterItensDaPagina([FromQuery] int pagina)
        {
            return Ok(await _saidaAppService.obterItensDaPagina(pagina));
        }

        [HttpGet("obter-todos-itens-pagina")]
        public async Task<IActionResult> obterTodosItensDaPagina()
        {
            return Ok(await _saidaAppService.obterTodosItensDaPagina());
        }

        [HttpPost("inserir-saida")]
        public async Task<IActionResult> InserirSaida(SaidaRequest saida)
        {
            if (saida == null)
                return BadRequest();

            await _saidaAppService.InserirSaida(saida);

            return Created("Created", true);
        }
    }
}
