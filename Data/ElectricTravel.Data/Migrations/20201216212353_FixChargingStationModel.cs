namespace ElectricTravel.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixChargingStationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingStations_Addresses_AddressId",
                table: "ChargingStations");

            migrationBuilder.DropIndex(
                name: "IX_ChargingStations_AddressId",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ChargingStations");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ChargingStations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ChargingStations");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ChargingStations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_ChargingStations_AddressId",
                table: "ChargingStations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingStations_Addresses_AddressId",
                table: "ChargingStations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
