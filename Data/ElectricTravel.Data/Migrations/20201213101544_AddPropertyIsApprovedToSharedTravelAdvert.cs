using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectricTravel.Data.Migrations
{
    public partial class AddPropertyIsApprovedToSharedTravelAdvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "SharedTravelAdverts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "SharedTravelAdverts");
        }
    }
}
