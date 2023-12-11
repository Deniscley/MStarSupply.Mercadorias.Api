using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.Mappings
{
    public class MercadoriaMapping : IEntityTypeConfiguration<Mercadoria>
    {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.ToTable("Mercadorias");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumeroRegistro)
                .HasColumnName("NumeroRegistro")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Fabricante)
                .HasColumnName("Fabricante")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnName("Tipo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
