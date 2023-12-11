using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MStarSupply.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupply.Data.Mappings
{
    public class SaidaMapping : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.ToTable("Saidas");

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
