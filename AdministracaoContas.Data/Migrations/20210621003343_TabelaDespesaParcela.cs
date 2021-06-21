using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministracaoContas.Data.Migrations
{
    public partial class TabelaDespesaParcela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DespesasParcela",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdDespesa = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Parcela = table.Column<int>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasParcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DespesasParcela_Despesas_IdDespesa",
                        column: x => x.IdDespesa,
                        principalTable: "Despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DespesasParcela_IdDespesa",
                table: "DespesasParcela",
                column: "IdDespesa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesasParcela");
        }
    }
}
