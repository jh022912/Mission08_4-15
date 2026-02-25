using Microsoft.AspNetCore.Mvc;
using Mission08_4_15.Data;
using Mission08_4_15.Models;

namespace Mission08_4_15.Controllers
{
    /// <summary>
    /// Main controller for the Covey Quadrant task management app.
    /// Handles displaying tasks by quadrant, adding/editing, deleting, and marking complete.
    /// </summary>
    public class HomeController : Controller
    {
        // Repository for data access (Repository Pattern)
        private readonly ITaskRepository _repository;

        public HomeController(ITaskRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Displays the Quadrants view with all uncompleted tasks organized by Covey quadrant.
        /// </summary>
        // GET: Home/Quadrants
        public IActionResult Quadrants()
        {
            var tasks = _repository.GetAllTasks();
            return View(tasks);
        }

        /// <summary>
        /// Displays the Add/Edit form. If id is provided, loads existing task for editing; otherwise shows empty form for new task.
        /// </summary>
        /// <param name="id">Optional task ID. Null = add new, non-null = edit existing.</param>
        // GET: Home/AddEdit
        public IActionResult AddEdit(int? id)
        {
            ViewBag.Categories = _repository.GetAllCategories();

            if (id != null)
            {
                var task = _repository.GetTaskById((int)id);
                return View(task);
            }

            return View(new TaskItem());
        }

        /// <summary>
        /// Processes the Add/Edit form. TaskItemId == 0 means add new; otherwise update existing.
        /// </summary>
        /// <param name="taskItem">The task data from the form (model binding).</param>
        // POST: Home/AddEdit
        [HttpPost]
        public IActionResult AddEdit(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                if (taskItem.TaskItemId == 0)
                {
                    _repository.AddTask(taskItem);
                }
                else
                {
                    _repository.UpdateTask(taskItem);
                }
                return RedirectToAction("Quadrants");
            }

            ViewBag.Categories = _repository.GetAllCategories();
            return View(taskItem);
        }

        /// <summary>
        /// Deletes a task by ID and redirects back to Quadrants.
        /// </summary>
        /// <param name="id">The TaskItemId of the task to delete.</param>
        // POST: Home/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteTask(id);
            return RedirectToAction("Quadrants");
        }

        /// <summary>
        /// Marks a task as completed. Completed tasks are hidden from the Quadrants view.
        /// </summary>
        /// <param name="id">The TaskItemId of the task to mark complete.</param>
        // POST: Home/MarkComplete
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repository.GetTaskById(id);
            if (task != null)
            {
                task.Completed = true;
                _repository.UpdateTask(task);
            }
            return RedirectToAction("Quadrants");
        }
    }
}