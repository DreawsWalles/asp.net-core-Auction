using project.Models.Adress;
using project.Models.Product;
using System;
using System.Collections.Generic;

namespace project.Models
{
    public class BiddingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Comments { get; set; }
        public string Path { get; set; }
        public AdressModel Adress { get; set; }
        public DateTime Date { get; set; }
        public List<string> Products { get; set; }
        public ICollection<ProductModel> ProductModels { get; set; }
    }
}
