using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemobsługiTeatru.Migrations
{
    /// <inheritdoc />
    public partial class showbookingtableupd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "ScreenNo",
               table: "Shows",
               type: "int",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScreenNo",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "ScreenNo",
               table: "Shows");

            migrationBuilder.DropColumn(
                name: "ScreenNo",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Bookings");
        }
    }
}
