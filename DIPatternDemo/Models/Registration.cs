using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        public string ?Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
