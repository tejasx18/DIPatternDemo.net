using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DIPatternDemo.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Id")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Employee Salary")]
        public decimal Salary { get; set; }
    }
}
