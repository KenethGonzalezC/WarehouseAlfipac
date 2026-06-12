using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWESOME.Migrations
{
    /// <inheritdoc />
    public partial class AperturasUbicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UbicacionActual",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UbicacionActual",
                table: "AperturasContenedores");
        }
    }
}
