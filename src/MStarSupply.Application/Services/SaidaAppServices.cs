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
    public class SaidaAppServices : ISaidaAppServices
    {
        private readonly ISaidaRepository _saidaRepository;
        private readonly ISaidaQueriesRepository _saidaQueriesRepository;
        public SaidaAppServices(ISaidaRepository saidaRepository, ISaidaQueriesRepository saidaQueriesRepository)
        {
            _saidaRepository = saidaRepository;
            _saidaQueriesRepository = saidaQueriesRepository;
        }

        public Task InserirSaida(Saida saida)
        {
            _saidaRepository.InserirSaida(saida);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<SaidaResponse>> ObterTodasSaidas()
        {
            var response = await _saidaQueriesRepository.ObterTodasSaidas();

            return response;
        }
    }
}
