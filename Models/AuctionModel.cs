using System;
using project.Models.Adress;
using project.Models.Product;
using System.Collections.Generic;

namespace project.Models
{
    public class AuctionModel
    {
        public int Id {  get; set; }
        public int TypeProductModelId { get; set; }
        public int UserModelId { get; set; }
        public int AdressModelId { get; set; }
        public DateTime dateTime { get; set; }
        
        public virtual TypeProductModel TypeProductModel { get; set; }
        public virtual UserModel UserModel { get; set; }
        public virtual AdressModel AdressModel { get; set; }
        public virtual ICollection<ProductAuctionModel> ProductAuctionModels { get; set; }
        public virtual ICollection<BettingHistory> BettingHistories { get; set; }
    }
}
