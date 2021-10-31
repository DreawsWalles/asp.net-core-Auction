using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Sername { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Phone(ErrorMessage = "Поле Телефон не является действительным номером телефона")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Поле Email не является действительным адресом электронной почты")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("VerifyLogin", "Account")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
