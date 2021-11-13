using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace project.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int? TypeProductModelId { get; set; }
        public int? UserModelId { get; set; }
        public string Name { get; set; }
        public bool IsBuy { get; set; }
        public DateTime Date { get; set; }
        public string? Comments { get; set; }
        public string Path { get; set; }
        public int Price { get; set; }
        

        public virtual TypeProductModel TypeProduct { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<ProductAuctionModel> ProductAuctionModels { get; set; } 
    }
}
