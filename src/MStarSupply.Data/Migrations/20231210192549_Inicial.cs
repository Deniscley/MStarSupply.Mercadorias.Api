using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MStarSupply.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroRegistro = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Local = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entradas_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Local = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saidas_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_MercadoriaId",
                table: "Entradas",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_MercadoriaId",
                table: "Saidas",
                column: "MercadoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Mercadorias");
        }
    }
}
