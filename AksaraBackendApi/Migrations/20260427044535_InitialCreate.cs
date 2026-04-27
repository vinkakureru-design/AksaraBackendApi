using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AksaraBackendApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataWargaModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wilayah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataWargaModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laporans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriMasalah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskripsiMasalah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LokasiMasalah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLaporan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoLaporan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdWargaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laporans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laporans_DataWargaModels_IdWargaId",
                        column: x => x.IdWargaId,
                        principalTable: "DataWargaModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laporans_IdWargaId",
                table: "Laporans",
                column: "IdWargaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laporans");

            migrationBuilder.DropTable(
                name: "DataWargaModels");
        }
    }
}
