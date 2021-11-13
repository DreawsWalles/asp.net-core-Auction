using System.Collections.Generic;

namespace project.Models
{
    public class TenderModel
    {
        public int Id { get; set; }
        public int AuctionModelId { get; set; }
        public string Name { get; set; }
        public int? ModeratorId { get; set; }

        public virtual AuctionModel AuctionModel { get; set; }
        public virtual UserModel Moderator { get; set; }
        public virtual ICollection<BettingHistory> BettingHistories { get; set; }
    }
}
