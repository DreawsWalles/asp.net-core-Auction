﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.DAL;

namespace project.asp.net.core.Migrations
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20211121150201_mig2")]
    partial class mig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("project.Models.Adress.AdressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostIndex")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("project.Models.AuctionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdressModelId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeProductModelId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isEnd")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AdressModelId");

                    b.HasIndex("TypeProductModelId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("project.Models.BettingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ProductAuctionModelId")
                        .HasColumnType("int");

                    b.Property<int?>("TenderId")
                        .HasColumnType("int");

                    b.Property<int?>("TenderModelsId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductAuctionModelId");

                    b.HasIndex("TenderModelsId");

                    b.HasIndex("UserModelId");

                    b.ToTable("BettingHistories");
                });

            modelBuilder.Entity("project.Models.FriendsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FriendOneId")
                        .HasColumnType("int");

                    b.Property<int?>("FriendTwoId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendOneId");

                    b.HasIndex("FriendTwoId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("project.Models.Person.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdressModelID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipientDetailsModelId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderDetailsModelId")
                        .HasColumnType("int");

                    b.Property<string>("Sername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdressModelID");

                    b.HasIndex("RecipientDetailsModelId");

                    b.HasIndex("SenderDetailsModelId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("project.Models.Person.RecipientDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("BIK")
                        .HasColumnType("int");

                    b.Property<int>("CorrespondentAccount")
                        .HasColumnType("int");

                    b.Property<int>("INN")
                        .HasColumnType("int");

                    b.Property<int>("KPP")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipientDetails");
                });

            modelBuilder.Entity("project.Models.Person.SenderDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CVC")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberCart")
                        .HasColumnType("int");

                    b.Property<string>("Sername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SenderDetails");
                });

            modelBuilder.Entity("project.Models.Product.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBuy")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("TypeProductModelId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeProductModelId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("project.Models.Product.TypeProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeProducts");
                });

            modelBuilder.Entity("project.Models.ProductAuctionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuctionModelId")
                        .HasColumnType("int");

                    b.Property<int?>("EndPrice")
                        .HasColumnType("int");

                    b.Property<int?>("PersonModelSellerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductModelId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelBuyerId")
                        .HasColumnType("int");

                    b.Property<bool?>("isCredit")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuctionModelId");

                    b.HasIndex("PersonModelSellerId");

                    b.HasIndex("ProductModelId");

                    b.HasIndex("UserModelBuyerId");

                    b.ToTable("ProductAuctions");
                });

            modelBuilder.Entity("project.Models.TenderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuctionModelId")
                        .HasColumnType("int");

                    b.Property<int?>("LotId")
                        .HasColumnType("int");

                    b.Property<int?>("ModeratorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionModelId");

                    b.HasIndex("LotId");

                    b.HasIndex("ModeratorId");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("project.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonModelId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonModelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("project.asp.net.core.Models.FileHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FileHistory");
                });

            modelBuilder.Entity("project.asp.net.core.Models.MessageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("project.Models.AuctionModel", b =>
                {
                    b.HasOne("project.Models.Adress.AdressModel", "AdressModel")
                        .WithMany("Auctions")
                        .HasForeignKey("AdressModelId");

                    b.HasOne("project.Models.Product.TypeProductModel", "TypeProductModel")
                        .WithMany("Auctions")
                        .HasForeignKey("TypeProductModelId");

                    b.HasOne("project.Models.UserModel", "UserModel")
                        .WithMany("AuctionModels")
                        .HasForeignKey("UserModelId");

                    b.Navigation("AdressModel");

                    b.Navigation("TypeProductModel");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("project.Models.BettingHistory", b =>
                {
                    b.HasOne("project.Models.ProductAuctionModel", "AuctionModel")
                        .WithMany()
                        .HasForeignKey("ProductAuctionModelId");

                    b.HasOne("project.Models.TenderModel", "TenderModels")
                        .WithMany("BettingHistories")
                        .HasForeignKey("TenderModelsId");

                    b.HasOne("project.Models.UserModel", "UserModel")
                        .WithMany("BettingHistories")
                        .HasForeignKey("UserModelId");

                    b.Navigation("AuctionModel");

                    b.Navigation("TenderModels");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("project.Models.FriendsModel", b =>
                {
                    b.HasOne("project.Models.UserModel", "FriendOne")
                        .WithMany()
                        .HasForeignKey("FriendOneId");

                    b.HasOne("project.Models.UserModel", "FriendTwo")
                        .WithMany()
                        .HasForeignKey("FriendTwoId");

                    b.Navigation("FriendOne");

                    b.Navigation("FriendTwo");
                });

            modelBuilder.Entity("project.Models.Person.PersonModel", b =>
                {
                    b.HasOne("project.Models.Adress.AdressModel", "Adress")
                        .WithMany("Persons")
                        .HasForeignKey("AdressModelID");

                    b.HasOne("project.Models.Person.RecipientDetailsModel", "RecipientDetailsModels")
                        .WithMany()
                        .HasForeignKey("RecipientDetailsModelId");

                    b.HasOne("project.Models.Person.SenderDetailsModel", "SenderDetails")
                        .WithMany()
                        .HasForeignKey("SenderDetailsModelId");

                    b.Navigation("Adress");

                    b.Navigation("RecipientDetailsModels");

                    b.Navigation("SenderDetails");
                });

            modelBuilder.Entity("project.Models.Product.ProductModel", b =>
                {
                    b.HasOne("project.Models.Product.TypeProductModel", "TypeProduct")
                        .WithMany("Products")
                        .HasForeignKey("TypeProductModelId");

                    b.HasOne("project.Models.UserModel", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserModelId");

                    b.Navigation("TypeProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("project.Models.ProductAuctionModel", b =>
                {
                    b.HasOne("project.Models.AuctionModel", "AuctionModel")
                        .WithMany("ProductAuctionModels")
                        .HasForeignKey("AuctionModelId");

                    b.HasOne("project.Models.Person.PersonModel", "PersonModelSeller")
                        .WithMany("ProductAuctionsSeller")
                        .HasForeignKey("PersonModelSellerId");

                    b.HasOne("project.Models.Product.ProductModel", "ProductModel")
                        .WithMany("ProductAuctionModels")
                        .HasForeignKey("ProductModelId");

                    b.HasOne("project.Models.UserModel", "UserModelBuyer")
                        .WithMany("ProductAuctionsBuyer")
                        .HasForeignKey("UserModelBuyerId");

                    b.Navigation("AuctionModel");

                    b.Navigation("PersonModelSeller");

                    b.Navigation("ProductModel");

                    b.Navigation("UserModelBuyer");
                });

            modelBuilder.Entity("project.Models.TenderModel", b =>
                {
                    b.HasOne("project.Models.AuctionModel", "AuctionModel")
                        .WithMany("Tenders")
                        .HasForeignKey("AuctionModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.ProductAuctionModel", "Lot")
                        .WithMany()
                        .HasForeignKey("LotId");

                    b.HasOne("project.Models.UserModel", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId");

                    b.Navigation("AuctionModel");

                    b.Navigation("Lot");

                    b.Navigation("Moderator");
                });

            modelBuilder.Entity("project.Models.UserModel", b =>
                {
                    b.HasOne("project.Models.Person.PersonModel", "PersonModel")
                        .WithMany()
                        .HasForeignKey("PersonModelId");

                    b.Navigation("PersonModel");
                });

            modelBuilder.Entity("project.asp.net.core.Models.MessageModel", b =>
                {
                    b.HasOne("project.Models.UserModel", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("project.Models.Adress.AdressModel", b =>
                {
                    b.Navigation("Auctions");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("project.Models.AuctionModel", b =>
                {
                    b.Navigation("ProductAuctionModels");

                    b.Navigation("Tenders");
                });

            modelBuilder.Entity("project.Models.Person.PersonModel", b =>
                {
                    b.Navigation("ProductAuctionsSeller");
                });

            modelBuilder.Entity("project.Models.Product.ProductModel", b =>
                {
                    b.Navigation("ProductAuctionModels");
                });

            modelBuilder.Entity("project.Models.Product.TypeProductModel", b =>
                {
                    b.Navigation("Auctions");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("project.Models.TenderModel", b =>
                {
                    b.Navigation("BettingHistories");
                });

            modelBuilder.Entity("project.Models.UserModel", b =>
                {
                    b.Navigation("AuctionModels");

                    b.Navigation("BettingHistories");

                    b.Navigation("ProductAuctionsBuyer");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
