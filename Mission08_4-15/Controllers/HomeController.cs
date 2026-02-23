using Microsoft.AspNetCore.Mvc;
using Mission08_4_15.Data;
using Mission08_4_15.Models;

namespace Mission08_4_15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repository;

        public HomeController(ITaskRepository repository)
        {
            _repository = repository;
        }

        // GET: Home/Quadrants
        public IActionResult Quadrants()
        {
            var tasks = _repository.GetAllTasks();
            return View(tasks);
        }

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

        // POST: Home/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteTask(id);
            return RedirectToAction("Quadrants");
        }

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