using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectricTravel.Data.Migrations
{
    public partial class AddProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ChargingStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChargingStations_CityId",
                table: "ChargingStations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingStations_Cities_CityId",
                table: "ChargingStations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingStations_Cities_CityId",
                table: "ChargingStations");

            migrationBuilder.DropIndex(
                name: "IX_ChargingStations_CityId",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ChargingStations");
        }
    }
}
