using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemobsługiTeatru.Migrations
{
    /// <inheritdoc />
    public partial class bookingtablekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Bookings",
                newName: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "OrderId");
        }
    }
}
