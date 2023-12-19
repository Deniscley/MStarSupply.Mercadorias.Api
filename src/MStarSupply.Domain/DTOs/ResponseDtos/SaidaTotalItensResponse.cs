using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.DTOs.ResponseDtos
{
    public class SaidaTotalItensResponse
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public int Quantidade_Total { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public int NumeroRegistro { get; set; }
        public Guid MercadoriaId { get; set; }
    }
}
