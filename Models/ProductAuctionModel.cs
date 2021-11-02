using project.Models.Person;
using project.Models.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class ProductAuctionModel
    {
        public int Id { get; set; }
        public int? AuctionModelId { get; set; }
        [ForeignKey("UserModelBuyer")]
        public int? UserModelBuyerId { get; set; }
        [ForeignKey("UserModelSeller")]
        public int? PersonModelSellerId { get; set; }
        public int? ProductModelId { get; set; }
        public int Number { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }
        public bool isCredit { get; set; }
        public string Comments { get; set; }

        public virtual UserModel UserModelBuyer { get; set; }
        public virtual AuctionModel AuctionModel { get; set; }
        public virtual PersonModel PersonModelSeller { get; set; }
        public virtual ProductModel ProductModel {  get; set; }
    }
}
