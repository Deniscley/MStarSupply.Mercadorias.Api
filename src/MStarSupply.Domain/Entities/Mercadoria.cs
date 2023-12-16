using MStarSupply.Core.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MStarSupply.Domain.Entities
{
    public class Mercadoria
    {
        [Key]
        public Guid Id { get; private set; }
        public int NumeroRegistro { get; private set; }
        public string Nome { get; private set; }
        public string Fabricante { get; private set; }

        public string Tipo { get; private set; }

        public string Descricao { get; private set; }

        public Mercadoria() { }

        public Mercadoria(int numeroRegistro, string nome, string fabricante, string tipo, string descricao)
        {
            Id = Guid.NewGuid();
            NumeroRegistro = numeroRegistro;
            Nome = nome;
            Fabricante = fabricante;
            Tipo = tipo;
            Descricao = descricao;
            Validate();
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Nome, "O campo Nome não pode estar vazio");
            Validations.ValidateIfEmpty(NumeroRegistro, "O campo NumeroRegistro não pode estar vazio");
            Validations.ValidateIfEmpty(Fabricante, "O campo Fabricante não pode estar vazio");
            Validations.ValidateIfEmpty(Tipo, "O campo Tipo não pode estar vazio");
            Validations.ValidateIfEmpty(Descricao, "O campo Descricao não pode estar vazio");
        }
    }


}
