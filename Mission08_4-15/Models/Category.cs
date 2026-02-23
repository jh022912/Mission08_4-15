using System.ComponentModel.DataAnnotations;

namespace Mission08_4_15.Models
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }

        [Required] public string CategoryName { get; set; }
    }
}