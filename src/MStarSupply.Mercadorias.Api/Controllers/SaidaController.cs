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
        private readonly ISaidaAppServices _saidaAppServices;
        public SaidaController(
            ISaidaAppServices saidaAppServices
        )
        {
            _saidaAppServices = saidaAppServices;
        }

        [HttpGet("obter-itens-pagina")]
        public async Task<IActionResult> obterItensDaPagina([FromQuery] int pagina)
        {
            return Ok(await _saidaAppServices.obterItensDaPagina(pagina));
        }

        [HttpGet("obter-todos-itens-pagina")]
        public async Task<IActionResult> obterTodosItensDaPagina()
        {
            return Ok(await _saidaAppServices.obterTodosItensDaPagina());
        }

        [HttpPost("inserir-saida")]
        public async Task<IActionResult> InserirSaida(SaidaRequest saida)
        {
            if (saida == null)
                return BadRequest();

            await _saidaAppServices.InserirSaida(saida);

            return Created("Created", true);
        }
    }
}
