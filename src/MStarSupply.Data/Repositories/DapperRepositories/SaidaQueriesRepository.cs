using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Interfaces.Repositories.DapperRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.Repositories.DapperRepositories
{
    public class SaidaQueriesRepository : ISaidaQueriesRepository
    {
        private string? ConnectionString;

        public SaidaQueriesRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<IEnumerable<SaidaResponse>> obterItensDaPagina(int pagina)
        {
            try
            {
                int itensPorPagina = 10;
                int paginaAtual = pagina;

                string sql = @"SELECT 
                                Saidas.Id AS Id,
                                Saidas.Local AS Local,
                                Saidas.Data AS Data,
                                Saidas.Quantidade AS Quantidade,
                                Saidas.MercadoriaId AS MercadoriaId,
                                Mercadorias.NumeroRegistro AS NumeroRegistro
                               FROM Saidas
                               INNER JOIN Mercadorias 
                               ON Saidas.MercadoriaId = Mercadorias.Id
                               WHERE MONTH(Saidas.Data) = MONTH(GETDATE())
                               AND YEAR(Saidas.Data) = YEAR(GETDATE())
                               ORDER BY Saidas.Data
                               OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parametros = new { Offset = (paginaAtual - 1) * itensPorPagina, PageSize = itensPorPagina };

                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                var resultado = await connection.QueryAsync<SaidaResponse>(sql, parametros);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }

        public async Task<IEnumerable<SaidaTotalItensResponse>> obterTodosItensDaPagina()
        {
            try
            {
                string sql = @"SELECT 
                                Saidas.Id AS Id,
                                Saidas.Local AS Local,
                                Saidas.Data AS Data,
                                Saidas.Quantidade AS Quantidade,
                                (SELECT SUM(Saidas.Quantidade) 
                                    FROM Saidas WHERE MONTH(Saidas.Data) = MONTH(GETDATE()) 
                                    AND YEAR(Saidas.Data) = YEAR(GETDATE())) AS Quantidade_Total,
                                Saidas.MercadoriaId AS MercadoriaId,
                                Mercadorias.NumeroRegistro AS NumeroRegistro
                               FROM Saidas
                               INNER JOIN Mercadorias 
                               ON Saidas.MercadoriaId = Mercadorias.Id
                               ORDER BY Saidas.Data";

                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                var resultado = await connection.QueryAsync<SaidaTotalItensResponse>(sql);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }
    }
}
