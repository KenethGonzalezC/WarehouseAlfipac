using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWESOME.Migrations
{
    /// <inheritdoc />
    public partial class CrearAperturasContenedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AperturasContenedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraApertura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroViaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transportista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marchamo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mercaderia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bultos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Embalaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArchivoExcel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AperturasContenedores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AperturasContenedores");
        }
    }
}
