using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UserTasksManager.Data;
using UserTasksManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserTasksManager.Controllers
{
    //Controller Level Route
    //[controller] : get the name of the class without Controller (users)
    [Route("api/[controller]")]
    [ApiController]
    //ControllerBase : Controller without Views.
    public class UsersController : ControllerBase
    {
        //Injection de dépandances
        private readonly IUserTasksRepo _repository;

        //Constructor
        public UsersController(IUserTasksRepo repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _repository.GetUsers();
            return Ok(users);
        }

        //GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<User> GetUserById(Guid id)
        {
            var user = _repository.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        //GET api/users/role/{role}
        [HttpGet("role/{role}")]
        public ActionResult<IEnumerable<User>> GetUsersByRole(Role role)
        {
            var users = _repository.GetUsersByRole(role);
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        //GET api/users/{id}/tasks
        [HttpGet("{id}/tasks")] 
        public ActionResult<IEnumerable<Task>> GetUserTasks(Guid id)
        {
            var tasks = _repository.GetUserTasks(_repository.GetUserById(id));
            if (tasks != null)
            {
                return Ok(tasks);
            }
            return NotFound();
        }

        //POST api/users
        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            _repository.AddUser(user);
            //SaveChanges : insert this new user into DB
            _repository.SaveChanges();
            return CreatedAtRoute(nameof(GetUserById), new { Id = user.Id }, user);
        }

        //PATCH api/users/tasks
        [HttpPatch("tasks")]
        public ActionResult<User> AddTasksToUser(User user, IEnumerable<Task> tasks, JsonPatchDocument<User> patchDocument)
        {
            //Check if the user is existant
            if (user == null)
            {
                return NotFound();
            }
            //Applying the patch
            patchDocument.ApplyTo(user, ModelState);

            if (!TryValidateModel(user))
            {
                return ValidationProblem(ModelState);
            }
            //Assigning task
            _repository.AddTasksToUser(user, tasks);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/users/{id}/tasks
        [HttpPatch("{id}/tasks")]
        public ActionResult<User> AddTasksToUser(Guid id, IEnumerable<Task> tasks, JsonPatchDocument<User> patchDocument)
        {
            var user = _repository.GetUserById(id);
            //Check if the user is existant
            if (user == null)
            {
                return NotFound();
            }
            //Applying the patch
            patchDocument.ApplyTo(user, ModelState);

            if (!TryValidateModel(user))
            {
                return ValidationProblem(ModelState);
            }
            //Assigning task
            _repository.AddTasksToUser(user, tasks);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
