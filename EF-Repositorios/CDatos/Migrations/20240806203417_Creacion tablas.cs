using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class Creaciontablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopiaLibro_Libro_LibroIdLibro",
                table: "CopiaLibro");

            migrationBuilder.DropForeignKey(
                name: "FK_CopiaLibro_Prestamo_IdPrestamo",
                table: "CopiaLibro");

            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Venta_IdVenta",
                table: "Libro");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_FormaPago_idFormaPago",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdVenta",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ID_COPIALIBRO",
                table: "CopiaLibro");

            migrationBuilder.DropIndex(
                name: "IX_CopiaLibro_LibroIdLibro",
                table: "CopiaLibro");

            migrationBuilder.DropColumn(
                name: "IdVenta",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "LibroIdLibro",
                table: "CopiaLibro");

            migrationBuilder.RenameTable(
                name: "CopiaLibro",
                newName: "Copia");

            migrationBuilder.RenameColumn(
                name: "idFormaPago",
                table: "Venta",
                newName: "IdFormaPago");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_idFormaPago",
                table: "Venta",
                newName: "IX_Venta_IdFormaPago");

            migrationBuilder.RenameColumn(
                name: "IdPrestamo",
                table: "Copia",
                newName: "IdLibro");

            migrationBuilder.RenameIndex(
                name: "IX_CopiaLibro_IdPrestamo",
                table: "Copia",
                newName: "IX_Copia_IdLibro");

            migrationBuilder.AddColumn<int>(
                name: "IdLibro",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCopia",
                table: "Prestamo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ID_COPIA",
                table: "Copia",
                column: "IdCopiaLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdLibro",
                table: "Venta",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdCopia",
                table: "Prestamo",
                column: "IdCopia");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_FormaPago_IdFormaPago",
                table: "Venta",
                column: "IdFormaPago",
                principalTable: "FormaPago",
                principalColumn: "IdFormaPago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Libro_IdLibro",
                table: "Venta",
                column: "IdLibro",
                principalTable: "Libro",
                principalColumn: "IdLibro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copia_Libro_IdLibro",
                table: "Copia");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Copia_IdCopia",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_FormaPago_IdFormaPago",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Libro_IdLibro",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdLibro",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Prestamo_IdCopia",
                table: "Prestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ID_COPIA",
                table: "Copia");

            migrationBuilder.DropColumn(
                name: "IdLibro",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IdCopia",
                table: "Prestamo");

            migrationBuilder.RenameTable(
                name: "Copia",
                newName: "CopiaLibro");

            migrationBuilder.RenameColumn(
                name: "IdFormaPago",
                table: "Venta",
                newName: "idFormaPago");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_IdFormaPago",
                table: "Venta",
                newName: "IX_Venta_idFormaPago");

            migrationBuilder.RenameColumn(
                name: "IdLibro",
                table: "CopiaLibro",
                newName: "IdPrestamo");

            migrationBuilder.RenameIndex(
                name: "IX_Copia_IdLibro",
                table: "CopiaLibro",
                newName: "IX_CopiaLibro_IdPrestamo");

            migrationBuilder.AddColumn<int>(
                name: "IdVenta",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LibroIdLibro",
                table: "CopiaLibro",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ID_COPIALIBRO",
                table: "CopiaLibro",
                column: "IdCopiaLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdVenta",
                table: "Libro",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_CopiaLibro_LibroIdLibro",
                table: "CopiaLibro",
                column: "LibroIdLibro");

            migrationBuilder.AddForeignKey(
                name: "FK_CopiaLibro_Libro_LibroIdLibro",
                table: "CopiaLibro",
                column: "LibroIdLibro",
                principalTable: "Libro",
                principalColumn: "IdLibro");

            migrationBuilder.AddForeignKey(
                name: "FK_CopiaLibro_Prestamo_IdPrestamo",
                table: "CopiaLibro",
                column: "IdPrestamo",
                principalTable: "Prestamo",
                principalColumn: "IdPrestamo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Venta_IdVenta",
                table: "Libro",
                column: "IdVenta",
                principalTable: "Venta",
                principalColumn: "IdVenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_FormaPago_idFormaPago",
                table: "Venta",
                column: "idFormaPago",
                principalTable: "FormaPago",
                principalColumn: "IdFormaPago",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
