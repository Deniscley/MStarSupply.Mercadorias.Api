﻿using MStarSupply.Domain.DTOs.ResponseDtos;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Services
{
    public interface IEntradaAppServices
    {
        Task InserirEntrada(Entrada entrada);

        Task<IEnumerable<EntradaResponse>> ObterTodasEntradas();
    }
}