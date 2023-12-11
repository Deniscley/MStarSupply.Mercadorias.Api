using Microsoft.AspNetCore.Mvc;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Controllers
{
    [Route("api/mercadoria")]
    [ApiController]
    public class MercadoriaController : Controller
    {
        private readonly IMercadoriaAppServices _mercadoriaAppServices;
        private readonly IMercadoriaRepository mercadoriaRepository;
        public MercadoriaController(
            IMercadoriaAppServices mercadoriaAppServices
        )
        {
            _mercadoriaAppServices = mercadoriaAppServices;
        }


        [HttpGet("obter-todas-mercadorias")]
        public async Task<IActionResult> ObterTodasMercadorias()
        {
            return Ok(await _mercadoriaAppServices.ObterTodasMercadorias());
        }

        [HttpGet("obter-todas-entradas")]
        public async Task<IActionResult> ObterTodasEntradas()
        {
            return Ok(await _mercadoriaAppServices.ObterTodasEntradas());
        }

        [HttpGet("obter-todas-saidas")]
        public async Task<IActionResult> ObterTodasSaidas()
        {
            return Ok(await _mercadoriaAppServices.ObterTodasSaidas());
        }


        [HttpPost("inserir-mercadoria")]
        public async Task<IActionResult> InserirMercadoria(Mercadoria mercadoria)
        {
            if (mercadoria == null)
                return BadRequest();

            await _mercadoriaAppServices.InserirMercadoria(mercadoria);

            return Created("Created", true);
        }

        [HttpPost("inserir-entrada")]
        public async Task<IActionResult> InserirEntrada(Entrada entrada)
        {
            if (entrada == null)
                return BadRequest();

            await _mercadoriaAppServices.InserirEntrada(entrada);

            return Created("Created", true);
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
