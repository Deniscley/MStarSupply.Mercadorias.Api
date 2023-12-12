using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Repositories.DapperRepositories;
using MStarSupply.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Application.Services
{
    public class MercadoriaAppServices : IMercadoriaAppServices
    {
        private readonly IMercadoriaRepository _mercadoriaRepository;
        private readonly IMercadoriaQueriesRepository _mercadoriaQueriesRepository;
        public MercadoriaAppServices(IMercadoriaRepository mercadoriaRepository, IMercadoriaQueriesRepository mercadoriaQueriesRepository)
        {
            _mercadoriaRepository = mercadoriaRepository;
            _mercadoriaQueriesRepository = mercadoriaQueriesRepository;
        }

        public Task InserirMercadoria(Mercadoria mercadoria)
        {
            _mercadoriaRepository.InserirMercadoria(mercadoria);
            return Task.CompletedTask;
        }

        public Task InserirEntrada(Entrada entrada)
        {
            _mercadoriaRepository.InserirEntrada(entrada);
            return Task.CompletedTask;
        }

        public Task InserirSaida(Saida saida)
        {
            _mercadoriaRepository.InserirSaida(saida);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias()
        {
            var response = await _mercadoriaRepository.ObterTodasMercadorias();

            return response;
        }

        public async Task<IEnumerable<EntradaResponse>> ObterTodasEntradas()
        {
            var response = await _mercadoriaQueriesRepository.ObterTodasEntradas();

            return response;
        }

        public async Task<IEnumerable<SaidaResponse>> ObterTodasSaidas()
        {
            var response = await _mercadoriaQueriesRepository.ObterTodasSaidas();

            return response;
        }
    }
}
