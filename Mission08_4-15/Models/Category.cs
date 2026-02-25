using System.ComponentModel.DataAnnotations;

namespace Mission08_4_15.Models
{
    /// <summary>
    /// Lookup table for task categories (Home, School, Work, Church).
    /// Used to populate the category dropdown in the Add/Edit Task form.
    /// </summary>
    public class Category
    {
        // Primary key for the category
        [Key]
        public int CategoryId { get; set; }

        // Display name of the category
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}