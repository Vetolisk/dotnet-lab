using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class LoginModel
    {
        [Required]
        public string login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
