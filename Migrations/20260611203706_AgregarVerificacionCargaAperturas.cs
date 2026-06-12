using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWESOME.Migrations
{
    /// <inheritdoc />
    public partial class AgregarVerificacionCargaAperturas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVerificacionCarga",
                table: "AperturasContenedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NoTransmision",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ObservacionesVerificacion",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RutaFirmaVerificacion",
                table: "AperturasContenedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Transmision",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionBalanceo",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionCompleta",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionDanada",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionFaltante",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionOtros1",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionOtros2",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionRevision",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionSobrante",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerificacionTrasiego",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaVerificacionCarga",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "NoTransmision",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "ObservacionesVerificacion",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "RutaFirmaVerificacion",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "Transmision",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionBalanceo",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionCompleta",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionDanada",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionFaltante",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionOtros1",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionOtros2",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionRevision",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionSobrante",
                table: "AperturasContenedores");

            migrationBuilder.DropColumn(
                name: "VerificacionTrasiego",
                table: "AperturasContenedores");
        }
    }
}
