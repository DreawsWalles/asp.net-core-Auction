using System.Collections.Generic;

namespace project.Models.Product
{
    public class TypeProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
        public virtual ICollection<AuctionModel> Auctions { get; set; }

    }
}
