using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string? CategoryName { get; set; }

    }
}
