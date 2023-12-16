using MStarSupply.Domain.DTOs.RequestDtos;
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
        private readonly IEntradaQueriesRepository _mercadoriaQueriesRepository;
        public MercadoriaAppServices(IMercadoriaRepository mercadoriaRepository, IEntradaQueriesRepository mercadoriaQueriesRepository)
        {
            _mercadoriaRepository = mercadoriaRepository;
            _mercadoriaQueriesRepository = mercadoriaQueriesRepository;
        }

        public Task InserirMercadoria(MercadoriaRequest mercadoria)
        {
            _mercadoriaRepository.InserirMercadoria(mercadoria);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias()
        {
            var response = await _mercadoriaRepository.ObterTodasMercadorias();

            return response;
        }
    }
}
