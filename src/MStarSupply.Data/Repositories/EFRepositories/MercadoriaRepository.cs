using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using MStarSupply.Data.Context;
using MStarSupply.Domain.DTOs.RequestDtos;
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
        public void InserirMercadoria(MercadoriaRequest mercadoria)
        {
            var mercadoriaResponse = _mapper.Map<Mercadoria>(mercadoria);
            _context.Mercadorias.Add(mercadoriaResponse);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias()
        {
            var response = (await _context.Mercadorias.AsNoTracking().ToListAsync()).AsEnumerable();
            var mercadoriasResponse = _mapper.Map<IEnumerable<MercadoriaResponse>>(response);
            return mercadoriasResponse;
        }
    }
}
