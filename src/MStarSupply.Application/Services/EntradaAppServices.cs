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
    public class EntradaAppServices : IEntradaAppServices
    {
        private readonly IEntradaRepository _entradaRepository;
        private readonly IEntradaQueriesRepository _entradaQueriesRepository;
        public EntradaAppServices(IEntradaRepository entradaRepository, IEntradaQueriesRepository entradaQueriesRepository)
        {
            _entradaRepository = entradaRepository;
            _entradaQueriesRepository = entradaQueriesRepository;
        }

        public Task InserirEntrada(EntradaRequest entrada)
        {
            _entradaRepository.InserirEntrada(entrada);
            return Task.CompletedTask;
        }


        public async Task<IEnumerable<EntradaResponse>> obterItensDaPagina(int pagina)
        {
            var response = await _entradaQueriesRepository.obterItensDaPagina(pagina);

            return response;
        }

        public async Task<IEnumerable<EntradaTotalItensResponse>> obterTodosItensDaPagina()
        {
            var response = await _entradaQueriesRepository.obterTodosItensDaPagina();

            return response;
        }

    }
}
