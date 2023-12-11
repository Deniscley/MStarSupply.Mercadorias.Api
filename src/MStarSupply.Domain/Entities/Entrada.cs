using MStarSupply.Core.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MStarSupply.Domain.Entities
{
    public class Entrada
    {
        [Key]
        public Guid Id { get; private set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Local {  get; set; }

        [ForeignKey("MercadoriaId")]
        public Guid MercadoriaId { get; set; }

        public Entrada() { }

        public Entrada(int quantidade, DateTime data, string local)
        {
            Id = Guid.NewGuid();
            Quantidade = quantidade;
            Data = data;
            Local = local;

            Validate();
        }

        public void Validate()
        {
            Validations.ValidateData(Data, "O campo data não pode estar vazio");
            Validations.ValidateIfEmpty(Local, "O campo local do cliente não pode estar vazio");
            Validations.ValidateIfEmpty(Quantidade, "O campo quantidade não pode estar vazio");
        }
    }
}
