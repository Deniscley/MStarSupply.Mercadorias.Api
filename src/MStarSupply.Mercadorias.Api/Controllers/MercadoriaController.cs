﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("inserir-mercadoria")]
        public async Task<IActionResult> InserirMercadoria(Mercadoria mercadoria)
        {
            if (mercadoria == null)
                return BadRequest();

            await _mercadoriaAppServices.InserirMercadoria(mercadoria);

            return Created("Created", true);
        }
    }
}
