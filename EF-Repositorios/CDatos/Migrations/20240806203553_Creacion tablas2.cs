using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class Creaciontablas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copia_Libro_IdLibro",
                table: "Copia");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Copia_IdCopia",
                table: "Prestamo");

            migrationBuilder.RenameTable(
                name: "Copia",
                newName: "CopiaLibro");

            migrationBuilder.RenameIndex(
                name: "IX_Copia_IdLibro",
                table: "CopiaLibro",
                newName: "IX_CopiaLibro_IdLibro");

            migrationBuilder.AddForeignKey(
                name: "FK_CopiaLibro_Libro_IdLibro",
                table: "CopiaLibro",
                column: "IdLibro",
                principalTable: "Libro",
                principalColumn: "IdLibro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_CopiaLibro_IdCopia",
                table: "Prestamo",
                column: "IdCopia",
                principalTable: "CopiaLibro",
                principalColumn: "IdCopiaLibro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopiaLibro_Libro_IdLibro",
                table: "CopiaLibro");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_CopiaLibro_IdCopia",
                table: "Prestamo");

            migrationBuilder.RenameTable(
                name: "CopiaLibro",
                newName: "Copia");

            migrationBuilder.RenameIndex(
                name: "IX_CopiaLibro_IdLibro",
                table: "Copia",
                newName: "IX_Copia_IdLibro");

            migrationBuilder.AddForeignKey(
                name: "FK_Copia_Libro_IdLibro",
                table: "Copia",
                column: "IdLibro",
                principalTable: "Libro",
                principalColumn: "IdLibro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Copia_IdCopia",
                table: "Prestamo",
                column: "IdCopia",
                principalTable: "Copia",
                principalColumn: "IdCopiaLibro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
