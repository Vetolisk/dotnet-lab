using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public bool status { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        [ForeignKey("Users")]
        public int userId { get; set; }
    }
}
