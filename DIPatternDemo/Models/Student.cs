using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Display(Name = "Student RollNo")]
        public int RollNo { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Student Branch")]
        public string? Branch { get; set; }

        [Required]
        [Display(Name = "Student Percentage")]
        [Range(minimum: 0, maximum: 100)]
        public decimal Percentage { get; set; }
    }
}
