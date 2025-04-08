using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawfectMatch.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_SexoId",
                table: "Mascotas",
                column: "SexoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Sexos_SexoId",
                table: "Mascotas",
                column: "SexoId",
                principalTable: "Sexos",
                principalColumn: "SexoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Sexos_SexoId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_SexoId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Mascotas");
        }
    }
}
