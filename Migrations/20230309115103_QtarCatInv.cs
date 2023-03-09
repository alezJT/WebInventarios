using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebInventarios.Migrations
{
    /// <inheritdoc />
    public partial class QtarCatInv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Inventario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Inventario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
