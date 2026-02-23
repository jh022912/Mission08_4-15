using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_4_15.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskItemId { get; set; }

        [Required(ErrorMessage = "Task is required")]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        public int Quadrant { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}