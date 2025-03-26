using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataNaFotografia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasFotografias_Fotografias_ListaFotografiasCompradasid",
                table: "ComprasFotografias");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Fotografias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ListaFotografiasCompradasid",
                table: "ComprasFotografias",
                newName: "ListaFotografiasCompradasId");

            migrationBuilder.RenameIndex(
                name: "IX_ComprasFotografias_ListaFotografiasCompradasid",
                table: "ComprasFotografias",
                newName: "IX_ComprasFotografias_ListaFotografiasCompradasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasFotografias_Fotografias_ListaFotografiasCompradasId",
                table: "ComprasFotografias",
                column: "ListaFotografiasCompradasId",
                principalTable: "Fotografias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasFotografias_Fotografias_ListaFotografiasCompradasId",
                table: "ComprasFotografias");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fotografias",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ListaFotografiasCompradasId",
                table: "ComprasFotografias",
                newName: "ListaFotografiasCompradasid");

            migrationBuilder.RenameIndex(
                name: "IX_ComprasFotografias_ListaFotografiasCompradasId",
                table: "ComprasFotografias",
                newName: "IX_ComprasFotografias_ListaFotografiasCompradasid");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasFotografias_Fotografias_ListaFotografiasCompradasid",
                table: "ComprasFotografias",
                column: "ListaFotografiasCompradasid",
                principalTable: "Fotografias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
