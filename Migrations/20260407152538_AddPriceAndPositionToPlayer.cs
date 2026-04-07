using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Testx.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceAndPositionToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 15.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 180.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Pomocnik", 180.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Pomocnik", 90.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 100.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Bramkarz", 10.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 60.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Pomocnik", 2.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 1.5m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 45.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Pomocnik", 90.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Obrońca", 3.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Pomocnik", 20.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Obrońca", 70.0m });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Position", "Price" },
                values: new object[] { "Napastnik", 110.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Players");
        }
    }
}
