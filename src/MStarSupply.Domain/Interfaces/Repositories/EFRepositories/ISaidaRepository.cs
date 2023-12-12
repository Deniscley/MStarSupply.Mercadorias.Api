using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Interfaces.Repositories.EFRepositories
{
    public interface ISaidaRepository
    {
        void InserirSaida(Saida saida);
    }
}
