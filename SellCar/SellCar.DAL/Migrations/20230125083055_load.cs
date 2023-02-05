using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellCar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class load : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                column: "YearCreate",
                value: new DateTime(2023, 1, 25, 11, 30, 55, 468, DateTimeKind.Local).AddTicks(2280));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                column: "YearCreate",
                value: new DateTime(2023, 1, 15, 18, 23, 9, 560, DateTimeKind.Local).AddTicks(1816));
        }
    }
}
