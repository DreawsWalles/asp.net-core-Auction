using Microsoft.EntityFrameworkCore;
using project.asp.net.core.Models;
using project.Models;
using project.Models.Adress;
using project.Models.Person;
using project.Models.Product;

namespace project.DAL
{
    public class AuctionContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductAuctionModel> ProductAuctions {  get; set; }   
        public DbSet<BettingHistory> BettingHistories { get; set; }
        public DbSet<AuctionModel> Auctions {  get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<AdressModel> Adresses { get; set; }
        public DbSet<RecipientDetailsModel> RecipientDetails { get; set; }
        public DbSet<SenderDetailsModel> SenderDetails {  get; set; }
        public DbSet<TypeProductModel> TypeProducts { get; set; }
        public DbSet<FileHistoryModel> FileHistory { get; set; }
        public DbSet<TenderModel> Tenders { get; set; }
        public DbSet<FriendsModel> Friends { get; set; }
        public DbSet<MessageModel> Messages { get; set; }

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
