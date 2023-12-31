﻿// <auto-generated />
using System;
using MStarSupply.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MStarSupply.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231210192549_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MStarSupply.Domain.Entities.Entrada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Local");

                    b.Property<Guid>("MercadoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MercadoriaId");

                    b.ToTable("Entradas", (string)null);
                });

            modelBuilder.Entity("MStarSupply.Domain.Entities.Mercadoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Fabricante");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("NumeroRegistro")
                        .HasColumnType("int")
                        .HasColumnName("NumeroRegistro");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Mercadorias", (string)null);
                });

            modelBuilder.Entity("MStarSupply.Domain.Entities.Saida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Local");

                    b.Property<Guid>("MercadoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MercadoriaId");

                    b.ToTable("Saidas", (string)null);
                });

            modelBuilder.Entity("MStarSupply.Domain.Entities.Entrada", b =>
                {
                    b.HasOne("MStarSupply.Domain.Entities.Mercadoria", null)
                        .WithMany()
                        .HasForeignKey("MercadoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MStarSupply.Domain.Entities.Saida", b =>
                {
                    b.HasOne("MStarSupply.Domain.Entities.Mercadoria", null)
                        .WithMany()
                        .HasForeignKey("MercadoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
