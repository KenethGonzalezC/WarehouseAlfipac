using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWESOME.Migrations
{
    /// <inheritdoc />
    public partial class correccionbools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anticipado",
                table: "AperturasContenedores");

            migrationBuilder.RenameColumn(
                name: "UsoCamaraRefrigerada",
                table: "AperturasContenedores",
                newName: "ServicioEspecialMontacargas5tons");

            migrationBuilder.RenameColumn(
                name: "ServicioMontacargas",
                table: "AperturasContenedores",
                newName: "ServicioEspecialMontacargas12tons");

            migrationBuilder.RenameColumn(
                name: "SeparacionMercaderia",
                table: "AperturasContenedores",
                newName: "ServicioAdicionalMontacargas");

            migrationBuilder.RenameColumn(
                name: "RollosPlasticos",
                table: "AperturasContenedores",
                newName: "SeparaciondeMercaderias");

            migrationBuilder.RenameColumn(
                name: "Reexportacion",
                table: "AperturasContenedores",
                newName: "PrevioExamen");

            migrationBuilder.RenameColumn(
                name: "ManejoEspecial",
                table: "AperturasContenedores",
                newName: "MovilizacionaAnden");

            migrationBuilder.RenameColumn(
                name: "InformacionCorreo",
                table: "AperturasContenedores",
                newName: "M6");

            migrationBuilder.RenameColumn(
                name: "Entarimado",
                table: "AperturasContenedores",
                newName: "M1");

            migrationBuilder.RenameColumn(
                name: "CargaSuelta",
                table: "AperturasContenedores",
                newName: "Flejeado");

            migrationBuilder.RenameColumn(
                name: "CargaPaletizada",
                table: "AperturasContenedores",
                newName: "EntarimadoyEmplasticado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServicioEspecialMontacargas5tons",
                table: "AperturasContenedores",
                newName: "UsoCamaraRefrigerada");

            migrationBuilder.RenameColumn(
                name: "ServicioEspecialMontacargas12tons",
                table: "AperturasContenedores",
                newName: "ServicioMontacargas");

            migrationBuilder.RenameColumn(
                name: "ServicioAdicionalMontacargas",
                table: "AperturasContenedores",
                newName: "SeparacionMercaderia");

            migrationBuilder.RenameColumn(
                name: "SeparaciondeMercaderias",
                table: "AperturasContenedores",
                newName: "RollosPlasticos");

            migrationBuilder.RenameColumn(
                name: "PrevioExamen",
                table: "AperturasContenedores",
                newName: "Reexportacion");

            migrationBuilder.RenameColumn(
                name: "MovilizacionaAnden",
                table: "AperturasContenedores",
                newName: "ManejoEspecial");

            migrationBuilder.RenameColumn(
                name: "M6",
                table: "AperturasContenedores",
                newName: "InformacionCorreo");

            migrationBuilder.RenameColumn(
                name: "M1",
                table: "AperturasContenedores",
                newName: "Entarimado");

            migrationBuilder.RenameColumn(
                name: "Flejeado",
                table: "AperturasContenedores",
                newName: "CargaSuelta");

            migrationBuilder.RenameColumn(
                name: "EntarimadoyEmplasticado",
                table: "AperturasContenedores",
                newName: "CargaPaletizada");

            migrationBuilder.AddColumn<bool>(
                name: "Anticipado",
                table: "AperturasContenedores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
