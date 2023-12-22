using Microsoft.AspNetCore.Mvc;
using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Controllers
{
    [Route("api/entrada")]
    [ApiController]
    public class EntradaController : Controller
    {
        private readonly IEntradaAppService _entradaAppService;
        public EntradaController(
            IEntradaAppService entradaAppService
        )
        {
            _entradaAppService = entradaAppService;
        }

        [HttpGet("obter-itens-pagina")]
        public async Task<IActionResult> obterItensDaPagina([FromQuery] int pagina)
        {
            return Ok(await _entradaAppService.obterItensDaPagina(pagina));
        }

        [HttpGet("obter-todos-itens-pagina")]
        public async Task<IActionResult> obterTodosItensDaPagina()
        {
            return Ok(await _entradaAppService.obterTodosItensDaPagina());
        }

        [HttpPost("inserir-entrada")]
        public async Task<IActionResult> InserirEntrada(EntradaRequest entrada)
        {
            if (entrada == null)
                return BadRequest();

            await _entradaAppService.InserirEntrada(entrada);

            return Created("Created", true);
        }
    }
}
