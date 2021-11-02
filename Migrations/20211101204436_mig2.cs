using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AdressModel_AdressModelId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_TypeProductModel_TypeProductModelId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Users_UserModelId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_BettingHistories_ProductAuctions_ProductAuctionModelId",
                table: "BettingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BettingHistories_Users_UserModelId",
                table: "BettingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AdressModel_AdressModelID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_RecipientDetailsModel_RecipientDetailsModelId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SenderDetailsModel_SenderDetailsModelId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Auctions_AuctionModelId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Products_ProductModelId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Users_UserModelBuyerId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProductModel_TypeProductModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonModelId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProductModel",
                table: "TypeProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SenderDetailsModel",
                table: "SenderDetailsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipientDetailsModel",
                table: "RecipientDetailsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdressModel",
                table: "AdressModel");

            migrationBuilder.DropColumn(
                name: "UserModelSellerId",
                table: "ProductAuctions");

            migrationBuilder.RenameTable(
                name: "TypeProductModel",
                newName: "TypeProducts");

            migrationBuilder.RenameTable(
                name: "SenderDetailsModel",
                newName: "SenderDetails");

            migrationBuilder.RenameTable(
                name: "RecipientDetailsModel",
                newName: "RecipientDetails");

            migrationBuilder.RenameTable(
                name: "AdressModel",
                newName: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "PersonModelId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserModelId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductModelId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserModelBuyerId",
                table: "ProductAuctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductModelId",
                table: "ProductAuctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuctionModelId",
                table: "ProductAuctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PersonModelSellerId",
                table: "ProductAuctions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserModelId",
                table: "BettingHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductAuctionModelId",
                table: "BettingHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserModelId",
                table: "Auctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductModelId",
                table: "Auctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdressModelId",
                table: "Auctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Sername",
                table: "SenderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SenderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SenderDetails",
                table: "SenderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipientDetails",
                table: "RecipientDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAuctions_PersonModelSellerId",
                table: "ProductAuctions",
                column: "PersonModelSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Adresses_AdressModelId",
                table: "Auctions",
                column: "AdressModelId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_TypeProducts_TypeProductModelId",
                table: "Auctions",
                column: "TypeProductModelId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Users_UserModelId",
                table: "Auctions",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BettingHistories_ProductAuctions_ProductAuctionModelId",
                table: "BettingHistories",
                column: "ProductAuctionModelId",
                principalTable: "ProductAuctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BettingHistories_Users_UserModelId",
                table: "BettingHistories",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Adresses_AdressModelID",
                table: "Persons",
                column: "AdressModelID",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_RecipientDetails_RecipientDetailsModelId",
                table: "Persons",
                column: "RecipientDetailsModelId",
                principalTable: "RecipientDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_SenderDetails_SenderDetailsModelId",
                table: "Persons",
                column: "SenderDetailsModelId",
                principalTable: "SenderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Auctions_AuctionModelId",
                table: "ProductAuctions",
                column: "AuctionModelId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Persons_PersonModelSellerId",
                table: "ProductAuctions",
                column: "PersonModelSellerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Products_ProductModelId",
                table: "ProductAuctions",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Users_UserModelBuyerId",
                table: "ProductAuctions",
                column: "UserModelBuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProducts_TypeProductModelId",
                table: "Products",
                column: "TypeProductModelId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserModelId",
                table: "Products",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonModelId",
                table: "Users",
                column: "PersonModelId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Adresses_AdressModelId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_TypeProducts_TypeProductModelId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Users_UserModelId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_BettingHistories_ProductAuctions_ProductAuctionModelId",
                table: "BettingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BettingHistories_Users_UserModelId",
                table: "BettingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Adresses_AdressModelID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_RecipientDetails_RecipientDetailsModelId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SenderDetails_SenderDetailsModelId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Auctions_AuctionModelId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Persons_PersonModelSellerId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Products_ProductModelId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAuctions_Users_UserModelBuyerId",
                table: "ProductAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProducts_TypeProductModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ProductAuctions_PersonModelSellerId",
                table: "ProductAuctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SenderDetails",
                table: "SenderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipientDetails",
                table: "RecipientDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PersonModelSellerId",
                table: "ProductAuctions");

            migrationBuilder.RenameTable(
                name: "TypeProducts",
                newName: "TypeProductModel");

            migrationBuilder.RenameTable(
                name: "SenderDetails",
                newName: "SenderDetailsModel");

            migrationBuilder.RenameTable(
                name: "RecipientDetails",
                newName: "RecipientDetailsModel");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "AdressModel");

            migrationBuilder.AlterColumn<int>(
                name: "PersonModelId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserModelId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductModelId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserModelBuyerId",
                table: "ProductAuctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductModelId",
                table: "ProductAuctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuctionModelId",
                table: "ProductAuctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelSellerId",
                table: "ProductAuctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserModelId",
                table: "BettingHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductAuctionModelId",
                table: "BettingHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserModelId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductModelId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdressModelId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sername",
                table: "SenderDetailsModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SenderDetailsModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProductModel",
                table: "TypeProductModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SenderDetailsModel",
                table: "SenderDetailsModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipientDetailsModel",
                table: "RecipientDetailsModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdressModel",
                table: "AdressModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AdressModel_AdressModelId",
                table: "Auctions",
                column: "AdressModelId",
                principalTable: "AdressModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_TypeProductModel_TypeProductModelId",
                table: "Auctions",
                column: "TypeProductModelId",
                principalTable: "TypeProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Users_UserModelId",
                table: "Auctions",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BettingHistories_ProductAuctions_ProductAuctionModelId",
                table: "BettingHistories",
                column: "ProductAuctionModelId",
                principalTable: "ProductAuctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BettingHistories_Users_UserModelId",
                table: "BettingHistories",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AdressModel_AdressModelID",
                table: "Persons",
                column: "AdressModelID",
                principalTable: "AdressModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_RecipientDetailsModel_RecipientDetailsModelId",
                table: "Persons",
                column: "RecipientDetailsModelId",
                principalTable: "RecipientDetailsModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_SenderDetailsModel_SenderDetailsModelId",
                table: "Persons",
                column: "SenderDetailsModelId",
                principalTable: "SenderDetailsModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Auctions_AuctionModelId",
                table: "ProductAuctions",
                column: "AuctionModelId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Products_ProductModelId",
                table: "ProductAuctions",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAuctions_Users_UserModelBuyerId",
                table: "ProductAuctions",
                column: "UserModelBuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProductModel_TypeProductModelId",
                table: "Products",
                column: "TypeProductModelId",
                principalTable: "TypeProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserModelId",
                table: "Products",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonModelId",
                table: "Users",
                column: "PersonModelId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
