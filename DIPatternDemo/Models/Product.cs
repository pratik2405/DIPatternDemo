using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Productid { get; set; }

        [Required]
        public string? Productname { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Categoryid { get; set; }

        [Required]
        public string ? ImageUrl { get; set; }

        [NotMapped]
        public string? Categoryname { get; set; }
    }
}
