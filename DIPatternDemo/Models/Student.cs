using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Sid { get; set; }

        [Required]
        [Display(Name ="Student Name")]
        public string ?Sname { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string ? Department { get; set; }

        [Required]
        [Display(Name = "Percentage ")]
        public decimal Percentage { get; set; }
    }
}
