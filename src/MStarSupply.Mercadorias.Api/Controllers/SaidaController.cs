using Microsoft.AspNetCore.Mvc;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Controllers
{
    [Route("api/saida")]
    [ApiController]
    public class SaidaController : Controller
    {
        private readonly IMercadoriaAppServices _mercadoriaAppServices;
        private readonly IMercadoriaRepository mercadoriaRepository;
        public SaidaController(
            IMercadoriaAppServices mercadoriaAppServices
        )
        {
            _mercadoriaAppServices = mercadoriaAppServices;
        }

        [HttpGet("obter-todas-saidas")]
        public async Task<IActionResult> ObterTodasSaidas()
        {
            return Ok(await _mercadoriaAppServices.ObterTodasSaidas());
        }

        [HttpPost("inserir-saida")]
        public async Task<IActionResult> InserirSaida(Saida saida)
        {
            if (saida == null)
                return BadRequest();

            await _mercadoriaAppServices.InserirSaida(saida);

            return Created("Created", true);
        }
    }
}
