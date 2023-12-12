using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.DTOs.RequestDtos
{
    public class SaidaRequest
    {
        public Guid Id { get; private set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public Guid MercadoriaId { get; set; }
    }
}
