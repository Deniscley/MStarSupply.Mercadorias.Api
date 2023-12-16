using AutoMapper;
using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.MappingsProfile
{
    public class EntradaMappingProfile : Profile
    {
        public EntradaMappingProfile() 
        {
            CreateMap<EntradaRequest, Entrada>();
        }
    }
}
