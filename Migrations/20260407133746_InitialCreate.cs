using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Testx.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Trophies = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Trophies = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false),
                    NationalityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "FoundationDate", "Name", "Trophies" },
                values: new object[,]
                {
                    { 1, new DateTime(1902, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Real Madryt", 100 },
                    { 2, new DateTime(1899, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "FC Barcelona", 95 },
                    { 3, new DateTime(1920, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jagiellonia Białystok", 2 }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Name", "Trophies" },
                values: new object[,]
                {
                    { 1, "Polska", 0 },
                    { 2, "Hiszpania", 4 },
                    { 3, "Brazylia", 5 },
                    { 4, "Anglia", 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "ClubId", "FirstName", "LastName", "NationalityId", "Weight" },
                values: new object[,]
                {
                    { 1, 35, 2, "Robert", "Lewandowski", 1, 81.0 },
                    { 2, 23, 1, "Vinicius", "Junior", 3, 73.0 },
                    { 3, 20, 1, "Jude", "Bellingham", 4, 75.0 },
                    { 4, 21, 2, "Pedri", "Gonzalez", 2, 60.0 },
                    { 5, 23, 1, "Rodrygo", "Goes", 3, 64.0 },
                    { 6, 34, 2, "Wojciech", "Szczęsny", 1, 90.0 },
                    { 7, 16, 2, "Lamine", "Yamal", 2, 65.0 },
                    { 8, 32, 3, "Taras", "Romanczuk", 1, 80.0 },
                    { 9, 33, 3, "Jesus", "Imaz", 2, 70.0 },
                    { 10, 17, 1, "Endrick", "Felipe", 3, 72.0 },
                    { 11, 19, 2, "Gavi", "Paez", 2, 68.0 },
                    { 12, 23, 3, "Bartłomiej", "Wdowik", 1, 74.0 },
                    { 13, 20, 2, "Fermin", "Lopez", 2, 66.0 },
                    { 14, 26, 1, "Eder", "Militao", 3, 79.0 },
                    { 15, 30, 1, "Harry", "Kane", 4, 86.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_NationalityId",
                table: "Players",
                column: "NationalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
