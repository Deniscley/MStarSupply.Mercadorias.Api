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
using MStarSupply.Domain.DTOs.RequestDtos;

namespace MStarSupply.Application.Services
{
    public class SaidaAppService : ISaidaAppService
    {
        private readonly ISaidaRepository _saidaRepository;
        private readonly ISaidaQueriesRepository _saidaQueriesRepository;
        public SaidaAppService(ISaidaRepository saidaRepository, ISaidaQueriesRepository saidaQueriesRepository)
        {
            _saidaRepository = saidaRepository;
            _saidaQueriesRepository = saidaQueriesRepository;
        }

        public Task InserirSaida(SaidaRequest saida)
        {
            _saidaRepository.InserirSaida(saida);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<SaidaResponse>> obterItensDaPagina(int pagina)
        {
            var response = await _saidaQueriesRepository.obterItensDaPagina(pagina);

            return response;
        }

        public async Task<IEnumerable<SaidaTotalItensResponse>> obterTodosItensDaPagina()
        {
            var response = await _saidaQueriesRepository.obterTodosItensDaPagina();

            return response;
        }
    }
}
