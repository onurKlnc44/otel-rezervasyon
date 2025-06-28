using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeodev.Migrations
{
    /// <inheritdoc />
    public partial class tablolar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Detay",
                columns: table => new
                {
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yıldız = table.Column<int>(type: "int", nullable: false),
                    Acıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Günlükfiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detay", x => x.MyProperty);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcı",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcı", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odaismi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetayID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oda_Detay_DetayID",
                        column: x => x.DetayID,
                        principalTable: "Detay",
                        principalColumn: "MyProperty",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Rezervarsyon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslangıcTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullanıcıId = table.Column<int>(type: "int", nullable: true),
                    OdaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervarsyon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervarsyon_Kullanıcı_KullanıcıId",
                        column: x => x.KullanıcıId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rezervarsyon_Oda_OdaID",
                        column: x => x.OdaID,
                        principalTable: "Oda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oda_DetayID",
                table: "Oda",
                column: "DetayID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervarsyon_KullanıcıId",
                table: "Rezervarsyon",
                column: "KullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervarsyon_OdaID",
                table: "Rezervarsyon",
                column: "OdaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervarsyon");

            migrationBuilder.DropTable(
                name: "Kullanıcı");

            migrationBuilder.DropTable(
                name: "Oda");

            migrationBuilder.DropTable(
                name: "Detay");
        }
    }
}
