using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWESOME.Migrations
{
    /// <inheritdoc />
    public partial class ExpedienteOperativo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anticipado",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CargaPaletizada",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CargaSuelta",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entarimado",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Etiquetado",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExtraccionMuestras",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAduana",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDespacho",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinalDescarga",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioDescarga",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInventario",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRepVacio",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalidaVacio",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraAduana",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraDespacho",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraFinalDescarga",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraIngreso",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraInicioDescarga",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraInventario",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraRepVacio",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraSalidaVacio",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InformacionCorreo",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ManejoEspecial",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarchamosAdicionales",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Peonaje",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reexportacion",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RollosPlasticos",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SeparacionMercaderia",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicioMontacargas",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tarimas",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UsoCamaraRefrigerada",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anticipado",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "CargaPaletizada",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "CargaSuelta",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Entarimado",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Etiquetado",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "ExtraccionMuestras",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaAduana",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaDespacho",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaFinalDescarga",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaInicioDescarga",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaInventario",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaRepVacio",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "FechaSalidaVacio",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraAduana",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraDespacho",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraFinalDescarga",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraIngreso",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraInicioDescarga",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraInventario",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraRepVacio",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "HoraSalidaVacio",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "InformacionCorreo",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "ManejoEspecial",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "MarchamosAdicionales",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Peonaje",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Reexportacion",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "RollosPlasticos",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "SeparacionMercaderia",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "ServicioMontacargas",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Tarimas",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "UsoCamaraRefrigerada",
                table: "AperturasContenedores");
        }
    }
}
