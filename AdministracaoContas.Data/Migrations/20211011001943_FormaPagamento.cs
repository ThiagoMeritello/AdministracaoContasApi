using Microsoft.EntityFrameworkCore.Migrations;

namespace AdministracaoContas.Data.Migrations
{
    public partial class FormaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_FormaPamento_CodigoFormaPagamento",
                table: "Despesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPamento",
                table: "FormaPamento");

            migrationBuilder.RenameTable(
                name: "FormaPamento",
                newName: "FormaPagamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_FormaPagamento_CodigoFormaPagamento",
                table: "Despesas",
                column: "CodigoFormaPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_FormaPagamento_CodigoFormaPagamento",
                table: "Despesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento");

            migrationBuilder.RenameTable(
                name: "FormaPagamento",
                newName: "FormaPamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPamento",
                table: "FormaPamento",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_FormaPamento_CodigoFormaPagamento",
                table: "Despesas",
                column: "CodigoFormaPagamento",
                principalTable: "FormaPamento",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
