using project.Models.Person;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project.Models.Adress
{
    public class AdressModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string City { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int PostIndex { get; set; }

        public virtual ICollection<PersonModel> Persons { get; set; }
        public virtual ICollection<AuctionModel> Auctions { get; set; }
    }
}
