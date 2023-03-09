using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.sql.Migrations
{
    public partial class alterandoparaNN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProdutos",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProdutos", x => new { x.CategoriasId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_CategoriaProdutos_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaProdutos_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProdutos_ProdutosId",
                table: "CategoriaProdutos",
                column: "ProdutosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaProdutos");
        }
    }
}
