using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeodev.Migrations
{
    /// <inheritdoc />
    public partial class tabloGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetayID",
                table: "Resimler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetayMyProperty",
                table: "Detay",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_DetayID",
                table: "Resimler",
                column: "DetayID");

            migrationBuilder.CreateIndex(
                name: "IX_Detay_DetayMyProperty",
                table: "Detay",
                column: "DetayMyProperty");

            migrationBuilder.AddForeignKey(
                name: "FK_Detay_Detay_DetayMyProperty",
                table: "Detay",
                column: "DetayMyProperty",
                principalTable: "Detay",
                principalColumn: "MyProperty");

            migrationBuilder.AddForeignKey(
                name: "FK_Resimler_Detay_DetayID",
                table: "Resimler",
                column: "DetayID",
                principalTable: "Detay",
                principalColumn: "MyProperty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detay_Detay_DetayMyProperty",
                table: "Detay");

            migrationBuilder.DropForeignKey(
                name: "FK_Resimler_Detay_DetayID",
                table: "Resimler");

            migrationBuilder.DropIndex(
                name: "IX_Resimler_DetayID",
                table: "Resimler");

            migrationBuilder.DropIndex(
                name: "IX_Detay_DetayMyProperty",
                table: "Detay");

            migrationBuilder.DropColumn(
                name: "DetayID",
                table: "Resimler");

            migrationBuilder.DropColumn(
                name: "DetayMyProperty",
                table: "Detay");
        }
    }
}
