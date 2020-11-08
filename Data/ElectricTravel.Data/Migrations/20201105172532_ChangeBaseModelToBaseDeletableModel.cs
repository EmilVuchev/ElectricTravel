namespace ElectricTravel.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeBaseModelToBaseDeletableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Videos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserRatings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserRatings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Sources",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sources",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SocketTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocketTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Sockets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sockets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SocketPowers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocketPowers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SharedTravelAdverts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SharedTravelAdverts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Regions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Models",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Makes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Makes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChatMessages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ChargingStations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChargingStations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CarTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CarAdverts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarAdverts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_IsDeleted",
                table: "Videos",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_IsDeleted",
                table: "UserRatings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_IsDeleted",
                table: "Sources",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SocketTypes_IsDeleted",
                table: "SocketTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_IsDeleted",
                table: "Sockets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SocketPowers_IsDeleted",
                table: "SocketPowers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SharedTravelAdverts_IsDeleted",
                table: "SharedTravelAdverts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_IsDeleted",
                table: "Regions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_IsDeleted",
                table: "PaymentMethods",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Models_IsDeleted",
                table: "Models",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_IsDeleted",
                table: "Makes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsDeleted",
                table: "Images",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IsDeleted",
                table: "Groups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IsDeleted",
                table: "Cities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_IsDeleted",
                table: "ChatMessages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingStations_IsDeleted",
                table: "ChargingStations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarTypes_IsDeleted",
                table: "CarTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IsDeleted",
                table: "Cars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdverts_IsDeleted",
                table: "CarAdverts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IsDeleted",
                table: "Articles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IsDeleted",
                table: "Addresses",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Videos_IsDeleted",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_IsDeleted",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_Sources_IsDeleted",
                table: "Sources");

            migrationBuilder.DropIndex(
                name: "IX_SocketTypes_IsDeleted",
                table: "SocketTypes");

            migrationBuilder.DropIndex(
                name: "IX_Sockets_IsDeleted",
                table: "Sockets");

            migrationBuilder.DropIndex(
                name: "IX_SocketPowers_IsDeleted",
                table: "SocketPowers");

            migrationBuilder.DropIndex(
                name: "IX_SharedTravelAdverts_IsDeleted",
                table: "SharedTravelAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Regions_IsDeleted",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_IsDeleted",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Models_IsDeleted",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Makes_IsDeleted",
                table: "Makes");

            migrationBuilder.DropIndex(
                name: "IX_Images_IsDeleted",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Groups_IsDeleted",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Cities_IsDeleted",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_IsDeleted",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChargingStations_IsDeleted",
                table: "ChargingStations");

            migrationBuilder.DropIndex(
                name: "IX_CarTypes_IsDeleted",
                table: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cars_IsDeleted",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarAdverts_IsDeleted",
                table: "CarAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Articles_IsDeleted",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SocketTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocketTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Sockets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sockets");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SocketPowers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocketPowers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SharedTravelAdverts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SharedTravelAdverts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CarTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CarAdverts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarAdverts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");
        }
    }
}
