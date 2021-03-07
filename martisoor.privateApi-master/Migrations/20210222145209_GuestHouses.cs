using Microsoft.EntityFrameworkCore.Migrations;

namespace bknsystem.privateApi.Migrations
{
    public partial class GuestHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_file_gueset_guest_house_guestHouse_id",
                table: "file_gueset");

            migrationBuilder.DropForeignKey(
                name: "FK_guest_rules_guest_house_guestHouse_id",
                table: "guest_rules");

            migrationBuilder.DropForeignKey(
                name: "FK_rating_guest_guest_house_guestHouse_id",
                table: "rating_guest");

            migrationBuilder.DropForeignKey(
                name: "FK_review_guest_guest_house_guestHouse_id",
                table: "review_guest");

            migrationBuilder.DropIndex(
                name: "IX_review_guest_guestHouse_id",
                table: "review_guest");

            migrationBuilder.DropIndex(
                name: "IX_rating_guest_guestHouse_id",
                table: "rating_guest");

            migrationBuilder.DropIndex(
                name: "IX_guest_rules_guestHouse_id",
                table: "guest_rules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guest_house",
                table: "guest_house");

            migrationBuilder.DropIndex(
                name: "IX_file_gueset_guestHouse_id",
                table: "file_gueset");

            migrationBuilder.DropColumn(
                name: "guestHouse_id",
                table: "review_guest");

            migrationBuilder.DropColumn(
                name: "guestHouse_id",
                table: "rating_guest");

            migrationBuilder.DropColumn(
                name: "guestHouse_id",
                table: "guest_rules");

            migrationBuilder.DropColumn(
                name: "_id",
                table: "guest_house");

            migrationBuilder.DropColumn(
                name: "guestHouse_id",
                table: "file_gueset");

            migrationBuilder.AddColumn<string>(
                name: "guestHouseid",
                table: "review_guest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guestHouseid",
                table: "rating_guest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guestHouseid",
                table: "guest_rules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "guest_house",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "guestHouseid",
                table: "file_gueset",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_guest_house",
                table: "guest_house",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_review_guest_guestHouseid",
                table: "review_guest",
                column: "guestHouseid");

            migrationBuilder.CreateIndex(
                name: "IX_rating_guest_guestHouseid",
                table: "rating_guest",
                column: "guestHouseid");

            migrationBuilder.CreateIndex(
                name: "IX_guest_rules_guestHouseid",
                table: "guest_rules",
                column: "guestHouseid");

            migrationBuilder.CreateIndex(
                name: "IX_file_gueset_guestHouseid",
                table: "file_gueset",
                column: "guestHouseid");

            migrationBuilder.AddForeignKey(
                name: "FK_file_gueset_guest_house_guestHouseid",
                table: "file_gueset",
                column: "guestHouseid",
                principalTable: "guest_house",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_guest_rules_guest_house_guestHouseid",
                table: "guest_rules",
                column: "guestHouseid",
                principalTable: "guest_house",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_guest_guest_house_guestHouseid",
                table: "rating_guest",
                column: "guestHouseid",
                principalTable: "guest_house",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_review_guest_guest_house_guestHouseid",
                table: "review_guest",
                column: "guestHouseid",
                principalTable: "guest_house",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_file_gueset_guest_house_guestHouseid",
                table: "file_gueset");

            migrationBuilder.DropForeignKey(
                name: "FK_guest_rules_guest_house_guestHouseid",
                table: "guest_rules");

            migrationBuilder.DropForeignKey(
                name: "FK_rating_guest_guest_house_guestHouseid",
                table: "rating_guest");

            migrationBuilder.DropForeignKey(
                name: "FK_review_guest_guest_house_guestHouseid",
                table: "review_guest");

            migrationBuilder.DropIndex(
                name: "IX_review_guest_guestHouseid",
                table: "review_guest");

            migrationBuilder.DropIndex(
                name: "IX_rating_guest_guestHouseid",
                table: "rating_guest");

            migrationBuilder.DropIndex(
                name: "IX_guest_rules_guestHouseid",
                table: "guest_rules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guest_house",
                table: "guest_house");

            migrationBuilder.DropIndex(
                name: "IX_file_gueset_guestHouseid",
                table: "file_gueset");

            migrationBuilder.DropColumn(
                name: "guestHouseid",
                table: "review_guest");

            migrationBuilder.DropColumn(
                name: "guestHouseid",
                table: "rating_guest");

            migrationBuilder.DropColumn(
                name: "guestHouseid",
                table: "guest_rules");

            migrationBuilder.DropColumn(
                name: "id",
                table: "guest_house");

            migrationBuilder.DropColumn(
                name: "guestHouseid",
                table: "file_gueset");

            migrationBuilder.AddColumn<string>(
                name: "guestHouse_id",
                table: "review_guest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guestHouse_id",
                table: "rating_guest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guestHouse_id",
                table: "guest_rules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_id",
                table: "guest_house",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "guestHouse_id",
                table: "file_gueset",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_guest_house",
                table: "guest_house",
                column: "_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_guest_guestHouse_id",
                table: "review_guest",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_rating_guest_guestHouse_id",
                table: "rating_guest",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_guest_rules_guestHouse_id",
                table: "guest_rules",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_file_gueset_guestHouse_id",
                table: "file_gueset",
                column: "guestHouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_file_gueset_guest_house_guestHouse_id",
                table: "file_gueset",
                column: "guestHouse_id",
                principalTable: "guest_house",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_guest_rules_guest_house_guestHouse_id",
                table: "guest_rules",
                column: "guestHouse_id",
                principalTable: "guest_house",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_guest_guest_house_guestHouse_id",
                table: "rating_guest",
                column: "guestHouse_id",
                principalTable: "guest_house",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_review_guest_guest_house_guestHouse_id",
                table: "review_guest",
                column: "guestHouse_id",
                principalTable: "guest_house",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
