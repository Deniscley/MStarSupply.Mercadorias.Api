using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Repositories
{
    public interface IMercadoriaRepository
    {
        void InserirMercadoria(Mercadoria mercadoria);

        Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias();
    }
}
