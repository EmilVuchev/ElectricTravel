namespace ElectricTravel.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixBugInModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAdverts_Currency_CurrencyId",
                table: "CarAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_ImageType_TypeId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedTravelAdverts_TypeTravel_TypeOfTravelId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_StationCategory_Category_CategoryId",
                table: "StationCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_StationCategory_ChargingStations_StationId",
                table: "StationCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeTravel",
                table: "TypeTravel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationCategory",
                table: "StationCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageType",
                table: "ImageType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "TypeTravel",
                newName: "TypeTravels");

            migrationBuilder.RenameTable(
                name: "StationCategory",
                newName: "StationCategories");

            migrationBuilder.RenameTable(
                name: "ImageType",
                newName: "ImageTypes");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.RenameIndex(
                name: "IX_TypeTravel_IsDeleted",
                table: "TypeTravels",
                newName: "IX_TypeTravels_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_StationCategory_StationId",
                table: "StationCategories",
                newName: "IX_StationCategories_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_StationCategory_IsDeleted",
                table: "StationCategories",
                newName: "IX_StationCategories_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_ImageType_IsDeleted",
                table: "ImageTypes",
                newName: "IX_ImageTypes_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Currency_IsDeleted",
                table: "Currencies",
                newName: "IX_Currencies_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeTravels",
                table: "TypeTravels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationCategories",
                table: "StationCategories",
                columns: new[] { "CategoryId", "StationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageTypes",
                table: "ImageTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAdverts_Currencies_CurrencyId",
                table: "CarAdverts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ImageTypes_TypeId",
                table: "Images",
                column: "TypeId",
                principalTable: "ImageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedTravelAdverts_TypeTravels_TypeOfTravelId",
                table: "SharedTravelAdverts",
                column: "TypeOfTravelId",
                principalTable: "TypeTravels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StationCategories_Category_CategoryId",
                table: "StationCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StationCategories_ChargingStations_StationId",
                table: "StationCategories",
                column: "StationId",
                principalTable: "ChargingStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAdverts_Currencies_CurrencyId",
                table: "CarAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_ImageTypes_TypeId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedTravelAdverts_TypeTravels_TypeOfTravelId",
                table: "SharedTravelAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_StationCategories_Category_CategoryId",
                table: "StationCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_StationCategories_ChargingStations_StationId",
                table: "StationCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeTravels",
                table: "TypeTravels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationCategories",
                table: "StationCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTypes",
                table: "ImageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "TypeTravels",
                newName: "TypeTravel");

            migrationBuilder.RenameTable(
                name: "StationCategories",
                newName: "StationCategory");

            migrationBuilder.RenameTable(
                name: "ImageTypes",
                newName: "ImageType");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.RenameIndex(
                name: "IX_TypeTravels_IsDeleted",
                table: "TypeTravel",
                newName: "IX_TypeTravel_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_StationCategories_StationId",
                table: "StationCategory",
                newName: "IX_StationCategory_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_StationCategories_IsDeleted",
                table: "StationCategory",
                newName: "IX_StationCategory_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_ImageTypes_IsDeleted",
                table: "ImageType",
                newName: "IX_ImageType_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Currencies_IsDeleted",
                table: "Currency",
                newName: "IX_Currency_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeTravel",
                table: "TypeTravel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationCategory",
                table: "StationCategory",
                columns: new[] { "CategoryId", "StationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageType",
                table: "ImageType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAdverts_Currency_CurrencyId",
                table: "CarAdverts",
                column: "CurrencyId",
                principalTable: "Currency",
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
                name: "FK_SharedTravelAdverts_TypeTravel_TypeOfTravelId",
                table: "SharedTravelAdverts",
                column: "TypeOfTravelId",
                principalTable: "TypeTravel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StationCategory_Category_CategoryId",
                table: "StationCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StationCategory_ChargingStations_StationId",
                table: "StationCategory",
                column: "StationId",
                principalTable: "ChargingStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
