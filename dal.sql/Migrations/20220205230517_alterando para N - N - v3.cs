using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.sql.Migrations
{
    public partial class alterandoparaNNv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaProdutos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
