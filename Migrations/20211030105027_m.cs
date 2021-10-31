using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdressModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipientDetailsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INN = table.Column<int>(type: "int", nullable: false),
                    KPP = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    BIK = table.Column<int>(type: "int", nullable: false),
                    CorrespondentAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientDetailsModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SenderDetailsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberCart = table.Column<int>(type: "int", nullable: false),
                    CVC = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderDetailsModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProductModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProductModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressModelID = table.Column<int>(type: "int", nullable: true),
                    SenderDetailsModelId = table.Column<int>(type: "int", nullable: true),
                    RecipientDetailsModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AdressModel_AdressModelID",
                        column: x => x.AdressModelID,
                        principalTable: "AdressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_RecipientDetailsModel_RecipientDetailsModelId",
                        column: x => x.RecipientDetailsModelId,
                        principalTable: "RecipientDetailsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_SenderDetailsModel_SenderDetailsModelId",
                        column: x => x.SenderDetailsModelId,
                        principalTable: "SenderDetailsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeProductModelId = table.Column<int>(type: "int", nullable: false),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    AdressModelId = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_AdressModel_AdressModelId",
                        column: x => x.AdressModelId,
                        principalTable: "AdressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auctions_TypeProductModel_TypeProductModelId",
                        column: x => x.TypeProductModelId,
                        principalTable: "TypeProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auctions_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeProductModelId = table.Column<int>(type: "int", nullable: false),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBuy = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_TypeProductModel_TypeProductModelId",
                        column: x => x.TypeProductModelId,
                        principalTable: "TypeProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAuctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionModelId = table.Column<int>(type: "int", nullable: false),
                    UserModelBuyerId = table.Column<int>(type: "int", nullable: false),
                    UserModelSellerId = table.Column<int>(type: "int", nullable: false),
                    ProductModelId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    StartPrice = table.Column<int>(type: "int", nullable: false),
                    EndPrice = table.Column<int>(type: "int", nullable: false),
                    isCredit = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAuctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAuctions_Auctions_AuctionModelId",
                        column: x => x.AuctionModelId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAuctions_Products_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAuctions_Users_UserModelBuyerId",
                        column: x => x.UserModelBuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BettingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    ProductAuctionModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AuctionModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BettingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BettingHistories_Auctions_AuctionModelId",
                        column: x => x.AuctionModelId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BettingHistories_ProductAuctions_ProductAuctionModelId",
                        column: x => x.ProductAuctionModelId,
                        principalTable: "ProductAuctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BettingHistories_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_AdressModelId",
                table: "Auctions",
                column: "AdressModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_TypeProductModelId",
                table: "Auctions",
                column: "TypeProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_UserModelId",
                table: "Auctions",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BettingHistories_AuctionModelId",
                table: "BettingHistories",
                column: "AuctionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BettingHistories_ProductAuctionModelId",
                table: "BettingHistories",
                column: "ProductAuctionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BettingHistories_UserModelId",
                table: "BettingHistories",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AdressModelID",
                table: "Persons",
                column: "AdressModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RecipientDetailsModelId",
                table: "Persons",
                column: "RecipientDetailsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SenderDetailsModelId",
                table: "Persons",
                column: "SenderDetailsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAuctions_AuctionModelId",
                table: "ProductAuctions",
                column: "AuctionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAuctions_ProductModelId",
                table: "ProductAuctions",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAuctions_UserModelBuyerId",
                table: "ProductAuctions",
                column: "UserModelBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductModelId",
                table: "Products",
                column: "TypeProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserModelId",
                table: "Products",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonModelId",
                table: "Users",
                column: "PersonModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BettingHistories");

            migrationBuilder.DropTable(
                name: "ProductAuctions");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TypeProductModel");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "AdressModel");

            migrationBuilder.DropTable(
                name: "RecipientDetailsModel");

            migrationBuilder.DropTable(
                name: "SenderDetailsModel");
        }
    }
}
