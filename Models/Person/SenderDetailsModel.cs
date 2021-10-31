using System;
using System.ComponentModel.DataAnnotations;

namespace project.Models.Person
{
    public class SenderDetailsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Sername { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int NumberCart { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int CVC { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime dateTime { get; set; }
    }
}
