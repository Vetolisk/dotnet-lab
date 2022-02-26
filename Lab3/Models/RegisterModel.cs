
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле 'Логин' не заполнено")]
        
        public string login { get; set; }

        [Required(ErrorMessage = "Поле 'Пароль' не заполнено")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]

        public string Password { get; set; }

        [Required(ErrorMessage = "Поле 'Подтвердите пароль' не заполнено")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string passwordConfirm { get; set; }

        [Required(ErrorMessage = "Поле 'Электронная почта' не заполнено")]
        public string email { get; set; }
        public string role { get; set; }
    }
}
