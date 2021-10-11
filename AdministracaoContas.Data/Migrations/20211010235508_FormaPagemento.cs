using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministracaoContas.Data.Migrations
{
    public partial class FormaPagemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaPagamento",
                table: "Despesas");

            migrationBuilder.AlterColumn<int>(
                name: "Parcela",
                table: "Despesas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Despesas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CodigoFormaPagamento",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaPagamento",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FormaPamento",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "varchar(20)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPamento", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CodigoFormaPagamento",
                table: "Despesas",
                column: "CodigoFormaPagamento",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_FormaPamento_CodigoFormaPagamento",
                table: "Despesas",
                column: "CodigoFormaPagamento",
                principalTable: "FormaPamento",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_FormaPamento_CodigoFormaPagamento",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "FormaPamento");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CodigoFormaPagamento",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "CodigoFormaPagamento",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "DiaPagamento",
                table: "Despesas");

            migrationBuilder.AlterColumn<int>(
                name: "Parcela",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Despesas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormaPagamento",
                table: "Despesas",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
