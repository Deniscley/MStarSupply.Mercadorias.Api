using AutoMapper;
using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.MappingsProfile
{
    public class SaidaMappingProfile : Profile
    {
        public SaidaMappingProfile()
        {
            CreateMap<SaidaRequest, Saida>();
        }
    }
}
