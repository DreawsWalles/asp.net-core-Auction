using System;
using project.Models.Adress;
using project.Models.Product;
using System.Collections.Generic;

namespace project.Models
{
    public class AuctionModel
    {
        public int Id {  get; set; }
        public int? TypeProductModelId { get; set; }
        public int? UserModelId { get; set; }
        public int? AdressModelId { get; set; }
        public DateTime dateTime { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Path { get; set; }
        public bool isEnd { get; set; }

        public virtual TypeProductModel TypeProductModel { get; set; }
        public virtual UserModel UserModel { get; set; }
        public virtual AdressModel AdressModel { get; set; }
        public virtual ICollection<ProductAuctionModel> ProductAuctionModels { get; set; }
        public virtual ICollection<TenderModel> Tenders { get; set; }
    }
}
