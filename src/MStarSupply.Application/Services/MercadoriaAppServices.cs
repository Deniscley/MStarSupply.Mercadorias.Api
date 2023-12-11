using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
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
        public MercadoriaAppServices(IMercadoriaRepository mercadoriaRepository)
        {
            _mercadoriaRepository = mercadoriaRepository;
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
            var response = await _mercadoriaRepository.ObterTodasEntradas();

            return response;
        }

        public async Task<IEnumerable<SaidaResponse>> ObterTodasSaidas()
        {
            var response = await _mercadoriaRepository.ObterTodasSaidas();

            return response;
        }
    }
}
