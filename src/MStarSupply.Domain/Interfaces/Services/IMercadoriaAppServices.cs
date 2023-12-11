using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Services
{
    public interface IMercadoriaAppServices
    {
        Task InserirMercadoria(Mercadoria mercadoria);

        Task InserirEntrada(Entrada entrada);

        Task InserirSaida(Saida saida);

        Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias();

        Task<IEnumerable<EntradaResponse>> ObterTodasEntradas();

        Task<IEnumerable<SaidaResponse>> ObterTodasSaidas();
    }
}
