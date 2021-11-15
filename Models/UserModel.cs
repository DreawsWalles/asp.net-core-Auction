using project.Models.Person;
using System.Collections.Generic;
using project.Models.Product;
using System.ComponentModel.DataAnnotations;
using project.asp.net.core.Models.Messanger;

namespace project.Models
{
    public class UserModel
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? PersonModelId { get; set; }
        public string? FilePath { get; set; }
        public decimal? Money { get; set; }
        public int? ReesterId { get; set; }

        public virtual PersonModel PersonModel { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
        public virtual ICollection<ProductAuctionModel> ProductAuctionsBuyer { get; set; }
        public virtual ICollection<AuctionModel> AuctionModels { get; set; }
        public virtual ICollection<BettingHistory> BettingHistories { get; set; }
    }
}
