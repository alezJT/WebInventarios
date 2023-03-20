using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebInventarios.Migrations
{
    /// <inheritdoc />
    public partial class addid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductosAlmacen",
                newName: "ProductosAlmacens");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductosAlmacens",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosAlmacens",
                table: "ProductosAlmacens",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosAlmacens",
                table: "ProductosAlmacens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductosAlmacens");

            migrationBuilder.RenameTable(
                name: "ProductosAlmacens",
                newName: "ProductosAlmacen");
        }
    }
}
