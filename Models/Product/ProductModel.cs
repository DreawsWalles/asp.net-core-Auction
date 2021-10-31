using System;
using System.Collections.Generic;

namespace project.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int TypeProductModelId { get; set; }
        public int UserModelId { get; set; }
        public string Name { get; set; }
        public bool IsBuy { get; set; }
        public DateTime Date { get; set; }

        public virtual TypeProductModel TypeProduct { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<ProductAuctionModel> ProductAuctionModels { get; set; } 
    }
}
