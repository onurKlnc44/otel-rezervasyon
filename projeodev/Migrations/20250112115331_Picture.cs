using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeodev.Migrations
{
    /// <inheritdoc />
    public partial class Picture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resimler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resimyolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Resimler_Oda_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Oda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_OdaId",
                table: "Resimler",
                column: "OdaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resimler");
        }
    }
}
