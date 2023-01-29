using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemobsługiTeatru.Migrations
{
    /// <inheritdoc />
    public partial class showbookingtableupd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatNo1",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatNo2",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatNo3",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNo1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SeatNo2",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SeatNo3",
                table: "Bookings");
        }
    }
}
