using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Interfaces.Repositories.DapperRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MStarSupply.Data.Repositories.DapperRepositories
{
    public class EntradaQueriesRepository : IEntradaQueriesRepository
    {
        private string? ConnectionString;

        public EntradaQueriesRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<EntradaResponse>> obterItensDaPagina(int pagina)
        {
            try
            {
                int itensPorPagina = 10;
                int paginaAtual = pagina;

                string sql = @"SELECT 
                                Entradas.Id AS Id,
                                Entradas.Local AS Local,
                                Entradas.Data AS Data,
                                Entradas.Quantidade AS Quantidade,
                                Entradas.MercadoriaId AS MercadoriaId,
                                Mercadorias.NumeroRegistro AS NumeroRegistro
                               FROM Entradas
                               INNER JOIN Mercadorias 
                               ON Entradas.MercadoriaId = Mercadorias.Id
                               WHERE MONTH(Entradas.Data) = MONTH(GETDATE())
                               AND YEAR(Entradas.Data) = YEAR(GETDATE())
                               ORDER BY Entradas.Data
                               OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parametros = new { Offset = (paginaAtual - 1) * itensPorPagina, PageSize = itensPorPagina };

                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                var resultado =  await connection.QueryAsync<EntradaResponse>(sql, parametros);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }

        public async Task<IEnumerable<EntradaTotalItensResponse>> obterTodosItensDaPagina()
        {
            try
            {
                string sql = @"SELECT 
                                Entradas.Id AS Id,
                                Entradas.Local AS Local,
                                Entradas.Data AS Data,
                                Entradas.Quantidade AS Quantidade,
                                (SELECT SUM(Entradas.Quantidade) 
                                    FROM Entradas WHERE MONTH(Entradas.Data) = MONTH(GETDATE()) 
                                    AND YEAR(Entradas.Data) = YEAR(GETDATE())) AS Quantidade_Total,
                                Entradas.MercadoriaId AS MercadoriaId,
                                Mercadorias.NumeroRegistro AS NumeroRegistro
                               FROM Entradas
                               INNER JOIN Mercadorias 
                               ON Entradas.MercadoriaId = Mercadorias.Id
                               WHERE MONTH(Entradas.Data) = MONTH(GETDATE())
                               AND YEAR(Entradas.Data) = YEAR(GETDATE())
                               ORDER BY Entradas.Data";

                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                var resultado = await connection.QueryAsync<EntradaTotalItensResponse>(sql);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao realizar a consulta" + ex.Message);
            }
        }
    }
}
