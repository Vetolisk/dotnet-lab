

using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string Password { get; set; }
        public User()
        {
            role = "Customers";
        }
    }
}
