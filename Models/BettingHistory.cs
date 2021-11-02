namespace project.Models
{
    public class BettingHistory
    {
        public int Id {  get; set; }
        public int? UserModelId { get; set; }
        public int? ProductAuctionModelId { get; set; }
        public int Price { get; set; }

        public virtual UserModel UserModel { get; set; }
        public virtual ProductAuctionModel AuctionModel { get; set; }
    }
}
