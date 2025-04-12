using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawfectMatch.Migrations
{
    /// <inheritdoc />
    public partial class Servicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesServicios",
                columns: table => new
                {
                    SolicitudesServiciosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudAdopcionId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesServicios", x => x.SolicitudesServiciosId);
                    table.ForeignKey(
                        name: "FK_SolicitudesServicios_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesServicios_SolicitudesAdopciones_SolicitudAdopcionId",
                        column: x => x.SolicitudAdopcionId,
                        principalTable: "SolicitudesAdopciones",
                        principalColumn: "SolicitudAdopcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesServicios_ServicioId",
                table: "SolicitudesServicios",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesServicios_SolicitudAdopcionId",
                table: "SolicitudesServicios",
                column: "SolicitudAdopcionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudesServicios");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
