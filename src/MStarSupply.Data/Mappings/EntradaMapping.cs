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
    public class EntradaMapping : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.ToTable("Entradas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                .IsRequired();


            builder.Property(x => x.Data)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(s => s.Local)
                .HasColumnName("Local")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property<Guid>("MercadoriaId");

            builder.HasOne<Mercadoria>()
                .WithMany()
                .HasForeignKey(s => s.MercadoriaId)
                .IsRequired();
        }
    }
}
