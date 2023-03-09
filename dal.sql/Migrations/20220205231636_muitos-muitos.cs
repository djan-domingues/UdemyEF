using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.sql.Migrations
{
    public partial class muitosmuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoCategoria",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCategoria", x => new { x.ProdutoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_ProdutoCategoria_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoCategoria_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCategoria_CategoriaId",
                table: "ProdutoCategoria",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoCategoria");
        }
    }
}
