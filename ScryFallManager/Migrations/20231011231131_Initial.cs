using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScryFallManager.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Idioma = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Texto = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    Raridade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Idioma = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CustoMana = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ColecaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartas_Colecao_ColecaoId",
                        column: x => x.ColecaoId,
                        principalTable: "Colecao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CartaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habilidades_Cartas_CartaId",
                        column: x => x.CartaId,
                        principalTable: "Cartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Legalidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Formato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Legal = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CartaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legalidade_Cartas_CartaId",
                        column: x => x.CartaId,
                        principalTable: "Cartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_ColecaoId",
                table: "Cartas",
                column: "ColecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_CartaId",
                table: "Habilidades",
                column: "CartaId");

            migrationBuilder.CreateIndex(
                name: "IX_Legalidade_CartaId",
                table: "Legalidade",
                column: "CartaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Legalidade");

            migrationBuilder.DropTable(
                name: "Cartas");

            migrationBuilder.DropTable(
                name: "Colecao");
        }
    }
}
