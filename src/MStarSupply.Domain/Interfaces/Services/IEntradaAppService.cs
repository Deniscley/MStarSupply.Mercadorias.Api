using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Services
{
    public interface IEntradaAppService
    {
        Task InserirEntrada(EntradaRequest entrada);

        Task<IEnumerable<EntradaResponse>> obterItensDaPagina(int pagina);

        Task<IEnumerable<EntradaTotalItensResponse>> obterTodosItensDaPagina();
    }
}
