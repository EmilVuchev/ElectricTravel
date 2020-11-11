namespace ElectricTravel.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RefactorDbModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SharedTravelAdverts");

            migrationBuilder.DropColumn(
                name: "TypeOfTravel",
                table: "SharedTravelAdverts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CarAdverts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarAdverts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Videos",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sources",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SocketTypes",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "SharedTravelAdverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfTravelId",
                table: "SharedTravelAdverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Images",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarTypes",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "CarAdverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CarAdverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarAdvertStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAdvertStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 2, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharedTravelStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedTravelStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTravel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTravel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationCategory", x => new { x.CategoryId, x.StationId });
                    table.ForeignKey(
                        name: "FK_StationCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationCategory_ChargingStations_StationId",
                        column: x => x.StationId,
                        principalTable: "ChargingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SharedTravelAdverts_StatusId",
                table: "SharedTravelAdverts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedTravelAdverts_TypeOfTravelId",
                table: "SharedTravelAdverts",
                column: "TypeOfTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TypeId",
                table: "Images",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdverts_CurrencyId",
                table: "CarAdverts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdverts_StatusId",
                table: "CarAdverts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdvertStatus_IsDeleted",
                table: "CarAdvertStatus",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IsDeleted",
                table: "Category",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_IsDeleted",
                table: "Currency",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ImageType_IsDeleted",
                table: "ImageType",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SharedTravelStatus_IsDeleted",
                table: "SharedTravelStatus",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StationCategory_IsDeleted",
                table: "StationCategory",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StationCategory_StationId",
                table: "StationCategory",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeTravel_IsDeleted",
                table: "TypeTravel",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAdverts_Currency_CurrencyId",
                table: "CarAdverts",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarAdverts_CarAdvertStatus_StatusId",
                table: "CarAdverts",
                column: "StatusId",
                principalTable: "CarAdvertStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ImageType_TypeId",
                table: "Images",
                column: "TypeId",
                principalTable: "ImageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedTravelAdverts_SharedTravelStatus_StatusId",
                table: "SharedTravelAdverts",
                column: "StatusId",
                principalTable: "SharedTravelStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedTravelAdverts_TypeTravel_TypeOfTravelId",
                table: "SharedTravelAdverts",
                column: "TypeOfTravelId",
                principalTable: "TypeTravel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAdverts_Currency_CurrencyId",
                table: "CarAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarAdverts_CarAdvertStatus_StatusId",
                table: "CarAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_ImageType_TypeId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedTravelAdverts_SharedTravelStatus_StatusId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedTravelAdverts_TypeTravel_TypeOfTravelId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses");

            migrationBuilder.DropTable(
                name: "CarAdvertStatus");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropTable(
                name: "SharedTravelStatus");

            migrationBuilder.DropTable(
                name: "StationCategory");

            migrationBuilder.DropTable(
                name: "TypeTravel");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_SharedTravelAdverts_StatusId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropIndex(
                name: "IX_SharedTravelAdverts_TypeOfTravelId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Images_TypeId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_CarAdverts_CurrencyId",
                table: "CarAdverts");

            migrationBuilder.DropIndex(
                name: "IX_CarAdverts_StatusId",
                table: "CarAdverts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropColumn(
                name: "TypeOfTravelId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "CarAdverts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CarAdverts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SocketTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SharedTravelAdverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfTravel",
                table: "SharedTravelAdverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "ChargingStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "CarAdverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarAdverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
