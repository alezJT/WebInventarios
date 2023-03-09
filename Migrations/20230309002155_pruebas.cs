using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebInventarios.Migrations
{
    /// <inheritdoc />
    public partial class pruebas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    IDAlmacen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionAlmacen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaAlmacen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.IDAlmacen);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "int", nullable: false),
                    IDAlmacen = table.Column<int>(type: "int", nullable: false),
                    CantidadInv = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoDesc = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    ProductoComentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoCan = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
