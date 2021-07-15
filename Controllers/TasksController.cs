using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserTasksManager.Data;
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

        //GET api/tasks/{title}
        [HttpGet("{title}")]
        public ActionResult<Task> GetTaskByTitle(string title)
        {
            var task = _repository.GetTaskByTitle(title);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        //GET api/tasks/{state}
        [HttpGet("{state}")]
        public ActionResult<IEnumerable<Task>> GetTasksByStatus(State state)
        {
            var tasks = _repository.GetTasksByStatus(state);
            if (tasks != null)
            {
                return Ok(tasks);
            }
            return NotFound();
        }
    }
}
