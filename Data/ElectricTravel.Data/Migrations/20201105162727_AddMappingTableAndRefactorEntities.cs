namespace ElectricTravel.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddMappingTableAndRefactorEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_ElectricTravelUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ElectricTravelUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ElectricTravelUserId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "ElectricityConsumption",
                table: "Cars",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Drive",
                table: "Cars",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Battery",
                table: "Cars",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CarTypeMakes",
                columns: table => new
                {
                    MakeId = table.Column<int>(nullable: false),
                    CarTypeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypeMakes", x => new { x.CarTypeId, x.MakeId });
                    table.ForeignKey(
                        name: "FK_CarTypeMakes_CarTypes_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarTypeMakes_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarTypeMakes_IsDeleted",
                table: "CarTypeMakes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarTypeMakes_MakeId",
                table: "CarTypeMakes",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarTypeMakes");

            migrationBuilder.AlterColumn<string>(
                name: "ElectricityConsumption",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Drive",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Battery",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "ElectricTravelUserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ElectricTravelUserId",
                table: "Cars",
                column: "ElectricTravelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_ElectricTravelUserId",
                table: "Cars",
                column: "ElectricTravelUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
