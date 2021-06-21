using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministracaoContas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    Loja = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Produto = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    FormaPagamento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Parcela = table.Column<int>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");
        }
    }
}
