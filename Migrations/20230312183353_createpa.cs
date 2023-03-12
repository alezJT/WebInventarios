using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebInventarios.Migrations
{
    /// <inheritdoc />
    public partial class createpa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductosAlmacen",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    IDAlmacen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosAlmacen");
        }
    }
}
