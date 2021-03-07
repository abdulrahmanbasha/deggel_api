using Microsoft.EntityFrameworkCore.Migrations;

namespace bknsystem.privateApi.Migrations
{
    public partial class AddedPriceGuestHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "guest_house",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "guest_house");
        }
    }
}
