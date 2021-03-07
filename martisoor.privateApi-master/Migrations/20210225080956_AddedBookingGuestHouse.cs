using Microsoft.EntityFrameworkCore.Migrations;

namespace bknsystem.privateApi.Migrations
{
    public partial class AddedBookingGuestHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guesthouse_booking",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    special_requirements = table.Column<string>(nullable: true),
                    guesthouse_id = table.Column<string>(nullable: true),
                    room_id = table.Column<string>(nullable: true),
                    booking_status = table.Column<string>(nullable: true),
                    booking_paymentid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guesthouse_booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_guesthouse_booking_booking_payment_booking_paymentid",
                        column: x => x.booking_paymentid,
                        principalTable: "booking_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guesthouse_booking_booking_paymentid",
                table: "guesthouse_booking",
                column: "booking_paymentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guesthouse_booking");
        }
    }
}
