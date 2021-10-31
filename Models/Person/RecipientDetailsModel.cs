using System.ComponentModel.DataAnnotations;

namespace project.Models.Person
{
    public class RecipientDetailsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int INN { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int KPP { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int BIK { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int CorrespondentAccount { get; set; }
    }
}
