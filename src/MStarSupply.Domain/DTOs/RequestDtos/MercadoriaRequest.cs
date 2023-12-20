using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Domain.DTOs.RequestDtos
{
    public class MercadoriaRequest
    {
        public int NumeroRegistro { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
