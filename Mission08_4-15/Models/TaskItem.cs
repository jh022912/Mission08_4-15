using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_4_15.Models
{
    /// <summary>
    /// Represents a task item in the Covey Quadrant time management system.
    /// Maps to the TaskItems table in the database.
    /// </summary>
    public class TaskItem
    {
        // Primary key for the task
        [Key]
        public int TaskItemId { get; set; }

        // Description of the task (required per assignment)
        [Required(ErrorMessage = "Task is required")]
        public string Task { get; set; } = string.Empty;

        // Optional due date for the task
        public DateTime? DueDate { get; set; }

        // Covey quadrant (1-4): Important/Urgent, Important/Not Urgent, etc.
        [Required(ErrorMessage = "Quadrant is required")]
        public int Quadrant { get; set; }

        // Optional category reference (Home, School, Work, Church)
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // Whether the task has been completed (only uncompleted tasks are displayed)
        public bool Completed { get; set; } = false;
    }
}