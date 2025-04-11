using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawfectMatch.Migrations
{
    /// <inheritdoc />
    public partial class Presentaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diapositivas",
                columns: table => new
                {
                    DiapositivaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTituloLeftActive = table.Column<bool>(type: "bit", nullable: false),
                    Titulo_Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitulo_Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTituloRightActive = table.Column<bool>(type: "bit", nullable: false),
                    Titulo_Right = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitulo_Right = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsButtonLefttActive = table.Column<bool>(type: "bit", nullable: false),
                    TextButton_Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkButton_Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsButtonRighttActive = table.Column<bool>(type: "bit", nullable: false),
                    TextButton_Right = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkButton_Right = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Animacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diapositivas", x => x.DiapositivaId);
                });

            migrationBuilder.CreateTable(
                name: "Presentaciones",
                columns: table => new
                {
                    PresentacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActiva = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentaciones", x => x.PresentacionId);
                });

            migrationBuilder.CreateTable(
                name: "PresentacionesDiapositivas",
                columns: table => new
                {
                    PresentacionDiapositivaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresentacionId = table.Column<int>(type: "int", nullable: false),
                    DiapositivaId = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentacionesDiapositivas", x => x.PresentacionDiapositivaId);
                    table.ForeignKey(
                        name: "FK_PresentacionesDiapositivas_Diapositivas_DiapositivaId",
                        column: x => x.DiapositivaId,
                        principalTable: "Diapositivas",
                        principalColumn: "DiapositivaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentacionesDiapositivas_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresentacionesDiapositivas_DiapositivaId",
                table: "PresentacionesDiapositivas",
                column: "DiapositivaId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentacionesDiapositivas_PresentacionId",
                table: "PresentacionesDiapositivas",
                column: "PresentacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentacionesDiapositivas");

            migrationBuilder.DropTable(
                name: "Diapositivas");

            migrationBuilder.DropTable(
                name: "Presentaciones");
        }
    }
}
