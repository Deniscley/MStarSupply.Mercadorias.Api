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
    public class SaidaRepository : ISaidaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SaidaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void InserirSaida(SaidaRequest saida)
        {
            var saidaResponse = _mapper.Map<Saida>(saida);
            _context.Saidas.Add(saidaResponse);
            _context.SaveChanges();
        }
    }
}
