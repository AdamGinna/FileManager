using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaveData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Files = table.Column<ulong>(nullable: false),
                    Bytes = table.Column<ulong>(nullable: false),
                    ImageFiles = table.Column<ulong>(nullable: false),
                    ImageBytes = table.Column<ulong>(nullable: false),
                    AudioFiles = table.Column<ulong>(nullable: false),
                    AudioBytes = table.Column<ulong>(nullable: false),
                    FilmFiles = table.Column<ulong>(nullable: false),
                    FilmBytes = table.Column<ulong>(nullable: false),
                    DocumentFiles = table.Column<ulong>(nullable: false),
                    DocumentBytes = table.Column<ulong>(nullable: false),
                    ArchFiles = table.Column<ulong>(nullable: false),
                    ArchBytes = table.Column<ulong>(nullable: false),
                    RestFiles = table.Column<ulong>(nullable: false),
                    RestBytes = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SavedDataDrives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedDataDrives", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SavedDataFiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    DataID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DataSetDrivesID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedDataFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SavedDataFiles_FilesData_DataID",
                        column: x => x.DataID,
                        principalTable: "FilesData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedDataFiles_SavedDataDrives_DataSetDrivesID",
                        column: x => x.DataSetDrivesID,
                        principalTable: "SavedDataDrives",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedDataFiles_DataID",
                table: "SavedDataFiles",
                column: "DataID");

            migrationBuilder.CreateIndex(
                name: "IX_SavedDataFiles_DataSetDrivesID",
                table: "SavedDataFiles",
                column: "DataSetDrivesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedDataFiles");

            migrationBuilder.DropTable(
                name: "FilesData");

            migrationBuilder.DropTable(
                name: "SavedDataDrives");
        }
    }
}
