using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectricTravel.Data.Migrations
{
    public partial class FixRatingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssessorId",
                table: "UserRatings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_AssessorId",
                table: "UserRatings",
                column: "AssessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_AspNetUsers_AssessorId",
                table: "UserRatings",
                column: "AssessorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_AspNetUsers_AssessorId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_AssessorId",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "AssessorId",
                table: "UserRatings");
        }
    }
}
