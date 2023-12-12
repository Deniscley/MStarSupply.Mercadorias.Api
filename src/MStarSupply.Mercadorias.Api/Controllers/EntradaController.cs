using Microsoft.AspNetCore.Mvc;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Controllers
{
    [Route("api/entrada")]
    [ApiController]
    public class EntradaController : Controller
    {
        private readonly IMercadoriaAppServices _mercadoriaAppServices;
        private readonly IMercadoriaRepository mercadoriaRepository;
        public EntradaController(
            IMercadoriaAppServices mercadoriaAppServices
        )
        {
            _mercadoriaAppServices = mercadoriaAppServices;
        }

        [HttpGet("obter-todas-entradas")]
        public async Task<IActionResult> ObterTodasEntradas()
        {
            return Ok(await _mercadoriaAppServices.ObterTodasEntradas());
        }

        [HttpPost("inserir-entrada")]
        public async Task<IActionResult> InserirEntrada(Entrada entrada)
        {
            if (entrada == null)
                return BadRequest();

            await _mercadoriaAppServices.InserirEntrada(entrada);

            return Created("Created", true);
        }
    }
}
