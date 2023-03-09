using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.sql.Migrations
{
    public partial class alterandopara11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");
        }
    }
}
