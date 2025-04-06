using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawfectMatch.Migrations
{
    /// <inheritdoc />
    public partial class Modelsandfix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adoptantes",
                columns: table => new
                {
                    AdoptanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptantes", x => x.AdoptanteId);
                    table.ForeignKey(
                        name: "FK_Adoptantes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoSolicitudes",
                columns: table => new
                {
                    EstadoSolicitudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitudes", x => x.EstadoSolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "RelacionSizes",
                columns: table => new
                {
                    RelacionSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionSizes", x => x.RelacionSizeId);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    SexoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    RazaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.RazaId);
                    table.ForeignKey(
                        name: "FK_Razas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId");
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    RazaId = table.Column<int>(type: "int", nullable: false),
                    RelacionSizeId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamano = table.Column<double>(type: "float", nullable: false),
                    FechaNacimieneto = table.Column<DateOnly>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.MascotaId);
                    table.ForeignKey(
                        name: "FK_Mascotas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "FK_Mascotas_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId");
                    table.ForeignKey(
                        name: "FK_Mascotas_RelacionSizes_RelacionSizeId",
                        column: x => x.RelacionSizeId,
                        principalTable: "RelacionSizes",
                        principalColumn: "RelacionSizeId");
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptanteId = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK_Citas_Adoptantes_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "Adoptantes",
                        principalColumn: "AdoptanteId");
                    table.ForeignKey(
                        name: "FK_Citas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "MascotaId");
                });

            migrationBuilder.CreateTable(
                name: "HistorialAdopciones",
                columns: table => new
                {
                    HistorialAdopcioneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptanteId = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    FechaAdopcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialAdopciones", x => x.HistorialAdopcioneId);
                    table.ForeignKey(
                        name: "FK_HistorialAdopciones_Adoptantes_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "Adoptantes",
                        principalColumn: "AdoptanteId");
                    table.ForeignKey(
                        name: "FK_HistorialAdopciones_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "MascotaId");
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesAdopciones",
                columns: table => new
                {
                    SolicitudAdopcionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptanteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesAdopciones", x => x.SolicitudAdopcionId);
                    table.ForeignKey(
                        name: "FK_SolicitudesAdopciones_Adoptantes_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "Adoptantes",
                        principalColumn: "AdoptanteId");
                    table.ForeignKey(
                        name: "FK_SolicitudesAdopciones_EstadoSolicitudes_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalTable: "EstadoSolicitudes",
                        principalColumn: "EstadoSolicitudId");
                    table.ForeignKey(
                        name: "FK_SolicitudesAdopciones_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "MascotaId");
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perros" },
                    { 2, "Gatos" }
                });

            migrationBuilder.InsertData(
                table: "EstadoSolicitudes",
                columns: new[] { "EstadoSolicitudId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "Aprobada" },
                    { 3, "Rechazada" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Adoptado" },
                    { 3, "No Disponible" }
                });

            migrationBuilder.InsertData(
                table: "RelacionSizes",
                columns: new[] { "RelacionSizeId", "Size" },
                values: new object[,]
                {
                    { 1, "Pequeño" },
                    { 2, "Mediano" },
                    { 3, "Grande" }
                });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Macho" },
                    { 2, "Hembra" }
                });

            migrationBuilder.InsertData(
                table: "Razas",
                columns: new[] { "RazaId", "CategoriaId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Labrador" },
                    { 2, 1, "Bulldog" },
                    { 3, 2, "Persa" },
                    { 4, 2, "Siamés" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptantes_Id",
                table: "Adoptantes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_AdoptanteId",
                table: "Citas",
                column: "AdoptanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MascotaId",
                table: "Citas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAdopciones_AdoptanteId",
                table: "HistorialAdopciones",
                column: "AdoptanteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAdopciones_MascotaId",
                table: "HistorialAdopciones",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_CategoriaId",
                table: "Mascotas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_EstadoId",
                table: "Mascotas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RelacionSizeId",
                table: "Mascotas",
                column: "RelacionSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_CategoriaId",
                table: "Razas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAdopciones_AdoptanteId",
                table: "SolicitudesAdopciones",
                column: "AdoptanteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAdopciones_EstadoSolicitudId",
                table: "SolicitudesAdopciones",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAdopciones_MascotaId",
                table: "SolicitudesAdopciones",
                column: "MascotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "HistorialAdopciones");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "SolicitudesAdopciones");

            migrationBuilder.DropTable(
                name: "Adoptantes");

            migrationBuilder.DropTable(
                name: "EstadoSolicitudes");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "RelacionSizes");
        }
    }
}
