using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStarSupply.Data.Context;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.Repositories
{
    public class MercadoriaRepository : IMercadoriaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MercadoriaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void InserirMercadoria(Mercadoria mercadoria)
        {
            _context.Mercadorias.Add(mercadoria);
            _context.SaveChanges();
        }

        public void InserirEntrada(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
            _context.SaveChanges();
        }

        public void InserirSaida(Saida saida)
        {
            _context.Saidas.Add(saida);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias()
        {
            var response = (await _context.Mercadorias.AsNoTracking().ToListAsync()).AsEnumerable();
            var mercadoriasResponse = _mapper.Map<IEnumerable<MercadoriaResponse>>(response);
            return mercadoriasResponse;
        }

        public async Task<IEnumerable<EntradaResponse>> ObterTodasEntradas()
        {
            var response = (await _context.Entradas.AsNoTracking().ToListAsync()).AsEnumerable();
            var entradasResponse = _mapper.Map<IEnumerable<EntradaResponse>>(response);
            return entradasResponse;
        }

        public async Task<IEnumerable<SaidaResponse>> ObterTodasSaidas()
        {
            var response = (await _context.Saidas.AsNoTracking().ToListAsync()).AsEnumerable();
            var saidasResponse = _mapper.Map<IEnumerable<SaidaResponse>>(response);
            return saidasResponse;
        }
    }
}
