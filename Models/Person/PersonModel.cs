using project.Models.Adress;
using System.Collections.Generic;

namespace project.Models.Person
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string? Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? AdressModelID { get; set; }
        public int? SenderDetailsModelId { get; set; }
        public int? RecipientDetailsModelId { get; set; }

        public virtual AdressModel Adress { get; set; }
        public virtual SenderDetailsModel SenderDetails { get; set; }
        public virtual RecipientDetailsModel RecipientDetailsModels { get; set; }
        public virtual ICollection<ProductAuctionModel> ProductAuctionsSeller { get; set; }
    }
}
