using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }

        [Required]
        public string ?Categoryname { get; set; }
    }
}
