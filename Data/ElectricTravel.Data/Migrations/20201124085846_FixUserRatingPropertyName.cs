namespace ElectricTravel.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixUserRatingPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "UserRatings",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "UserRatings",
                newName: "Rating");
        }
    }
}
