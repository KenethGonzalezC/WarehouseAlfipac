using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWESOME.Migrations
{
    /// <inheritdoc />
    public partial class ObservacionesOperativas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anotaciones",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bodega",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dua",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Factura",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inventario",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anotaciones",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Bodega",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Dua",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Factura",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Inventario",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "AperturasContenedores");
        }
    }
}
