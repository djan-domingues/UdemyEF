using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.sql.Migrations
{
    public partial class alterandoparaNNv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Categorias");
        }
    }
}
