using MStarSupply.Domain.Interfaces.Repositories.DapperRepositories;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Interfaces.Repositories.EFRepositories;

namespace MStarSupply.Application.Services
{
    public class EntradaAppServices : IEntradaAppServices
    {
        private readonly IEntradaRepository _entradaRepository;
        private readonly IEntradaQueriesRepository _entradaQueriesRepository;
        public EntradaAppServices(IEntradaRepository entradaRepository, IEntradaQueriesRepository entradaQueriesRepository)
        {
            _entradaRepository = entradaRepository;
            _entradaQueriesRepository = entradaQueriesRepository;
        }

        public Task InserirEntrada(Entrada entrada)
        {
            _entradaRepository.InserirEntrada(entrada);
            return Task.CompletedTask;
        }


        public async Task<IEnumerable<EntradaResponse>> ObterTodasEntradas()
        {
            var response = await _entradaQueriesRepository.ObterTodasEntradas();

            return response;
        }

    }
}
