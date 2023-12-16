using AutoMapper;
using MStarSupply.Data.Context;
using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.Entities;
using MStarSupply.Domain.Interfaces.Repositories.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.Repositories.EFRepositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EntradaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void InserirEntrada(EntradaRequest entrada)
        {
            var entradaResponse = _mapper.Map<Entrada>(entrada);
            _context.Entradas.Add(entradaResponse);
            _context.SaveChanges();
        }
    }
}
