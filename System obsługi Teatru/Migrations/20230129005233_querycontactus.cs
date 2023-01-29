using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemobsługiTeatru.Migrations
{
    /// <inheritdoc />
    public partial class querycontactus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Shows",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Shows",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
