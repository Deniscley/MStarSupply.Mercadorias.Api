﻿using MStarSupply.Domain.DTOs.RequestDtos;
using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Services
{
    public interface IMercadoriaAppService
    {
        Task InserirMercadoria(MercadoriaRequest mercadoria);

        Task<IEnumerable<MercadoriaResponse>> ObterTodasMercadorias();
    }
}
