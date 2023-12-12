﻿using Microsoft.AspNetCore.Mvc;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Controllers
{
    [Route("api/entrada")]
    [ApiController]
    public class EntradaController : Controller
    {
        private readonly IEntradaAppServices _entradaAppServices;
        public EntradaController(
            IEntradaAppServices entradaAppServices
        )
        {
            _entradaAppServices = entradaAppServices;
        }

        [HttpGet("obter-todas-entradas")]
        public async Task<IActionResult> ObterTodasEntradas()
        {
            return Ok(await _entradaAppServices.ObterTodasEntradas());
        }

        [HttpPost("inserir-entrada")]
        public async Task<IActionResult> InserirEntrada(Entrada entrada)
        {
            if (entrada == null)
                return BadRequest();

            await _entradaAppServices.InserirEntrada(entrada);

            return Created("Created", true);
        }
    }
}