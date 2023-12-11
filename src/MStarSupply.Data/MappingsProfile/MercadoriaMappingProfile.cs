using AutoMapper;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.Mappings
{
    public class MercadoriaMappingProfile : Profile
    {
        public MercadoriaMappingProfile()
        {
            CreateMap<Mercadoria, MercadoriaResponse>();
            CreateMap<Entrada, EntradaResponse>();
            CreateMap<Saida, SaidaResponse>();
        }
    }
}
