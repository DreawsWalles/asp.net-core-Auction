using project.DAL;
using project.Models.Product;
using System.Linq;

namespace project.asp.net.core.DAL
{
    public static class SampleData
    {
        public static void Initialize(AuctionContext context)
        {
            if(!context.TypeProducts.Any())
            {
                context.TypeProducts.AddRange(
                    new TypeProductModel { Name = "Авто" },
                    new TypeProductModel { Name = "Еда" },
                    new TypeProductModel { Name = "Одежда" },
                    new TypeProductModel { Name = "Недвижимость" },
                    new TypeProductModel { Name = "Культура" },
                    new TypeProductModel { Name = "Чай" }
                    );
                context.SaveChanges();
            }
        }
    }
}
