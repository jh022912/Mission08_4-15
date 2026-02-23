using Microsoft.EntityFrameworkCore;
using Mission08_4_15.Models;
using Mission08_4_15.Data;

namespace Mission08_4_15.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAllTasks()
        {
            return _context.TaskItems
                .Include(t => t.Category)
                .Where(t => !t.Completed)
                .ToList();
        }

        public TaskItem? GetTaskById(int id)
        {
            return _context.TaskItems
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TaskItemId == id);
        }

        public void AddTask(TaskItem task)
        {
            _context.TaskItems.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskItem task)
        {
            _context.TaskItems.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}