using Mission08_4_15.Models;

namespace Mission08_4_15.Data
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAllTasks();
        TaskItem? GetTaskById(int id);
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
        List<Category> GetAllCategories();
    }
}