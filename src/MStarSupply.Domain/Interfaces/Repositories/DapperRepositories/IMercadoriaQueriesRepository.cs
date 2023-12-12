using MStarSupply.Domain.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Repositories.DapperRepositories
{
    public interface IMercadoriaQueriesRepository
    {
        Task<IEnumerable<EntradaResponse>> ObterTodasEntradas();

        Task<IEnumerable<SaidaResponse>> ObterTodasSaidas();
    }
}
