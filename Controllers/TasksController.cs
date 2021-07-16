using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UserTasksManager.Data;
using UserTasksManager.Models;
using static UserTasksManager.Models.Task;

namespace UserTasksManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //Injection de dépandances
        private readonly IUserTasksRepo _repository;

        //Constructor
        public TasksController(IUserTasksRepo repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            var tasks = _repository.GetTasks();
            return Ok(tasks);
        }

        //GET api/tasks/title/{title}
        [HttpGet("title/{title}",Name = "GetTaskByTitle")]
        public ActionResult<Task> GetTaskByTitle(string title)
        {
            var task = _repository.GetTaskByTitle(title);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        //GET api/tasks/status/{state}
        [HttpGet("status/{state}")]
        public ActionResult<IEnumerable<Task>> GetTasksByStatus(State state)
        {
            var tasks = _repository.GetTasksByStatus(state);
            if (tasks != null)
            {
                return Ok(tasks);
            }
            return NotFound();
        }

        //POST api/tasks
        [HttpPost]
        public ActionResult<Task> AddTask(Task task)
        {
            _repository.AddTask(task);
            //SaveChanges : insert this new task into DB
            _repository.SaveChanges();
            return CreatedAtRoute(nameof(GetTaskByTitle), new { Title = task.Title }, task);
        }
    }
}
