using System;
using System.Collections.Generic;
using System.Linq;
using UserTasksManager.Models;

namespace UserTasksManager.Data
{
    public class UserTasksRepo : IUserTasksRepo
    {
        private readonly UserTasksContext _context;

        //Constructor
        public UserTasksRepo(UserTasksContext context)
        {
            _context = context;
        }
        //POST
        public Models.Task AddTask(Models.Task task)
        {
            if (task == null)
            {
                //A nameof expression produces the name of a variable, type, or member as the string constant
                throw new ArgumentNullException(nameof(task));
            }
            _context.Tasks.Add(task);
            return task;
        }

        public IEnumerable<Models.Task> AddTasksToUser(User user, IEnumerable<Models.Task> tasks)
        {
            if (user == null)
            {
                //A nameof expression produces the name of a variable, type, or member as the string constant
                throw new ArgumentNullException(nameof(user));
            }
            _context.Tasks.Where(task => task.users.Contains(user));
            //want to add task : didn't find how to ??
            return null;
        }

        public IEnumerable<Models.Task> AddTasksToUser(string username, IEnumerable<Models.Task> tasks)
        {
            throw new NotImplementedException();
        }

        public User AddUser(User user)
        {
            if (user == null)
            {
                //A nameof expression produces the name of a variable, type, or member as the string constant
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
            return user;
        }

        //GET
        public Models.Task GetTaskByTitle(string title)
        {
            //SingleOrDefault : LINQ Operation = returns the only element which satisfies a given condition.
            //But when this condition returns more than one element or the collection is empty, the method returns a default value
            return _context.Tasks.SingleOrDefault(t => t.Title.Equals(title));
        }

        public IEnumerable<Models.Task> GetTasks()
        {
            //ToList : LINQ Operation
            return _context.Tasks.ToList();
        }

        public IEnumerable<Models.Task> GetTasksByStatus(Models.Task.State state)
        {
            //ToList & Where : LINQ Operations
            return _context.Tasks.Where(task => task.Status.Equals(state)).ToList();
        }

        public IEnumerable<User> GetUsers()
        {
            //OrderByDescending : LINQ Operation = the collection is sorted in a descending order.
            return _context.Users.OrderByDescending(user => user.DateCreated).ToList();
        }

        public IEnumerable<User> GetUsersByRole(Role role)
        {
            //ToList & Where : LINQ Operations
            return _context.Users.Where(user => user.role.Equals(role)).OrderByDescending(user => user.DateCreated).ToList();
        }

        public IEnumerable<Models.Task> GetUserTasks(User user)
        {
            return _context.Tasks.Where(task => task.users.Contains(user)).ToList();
        }

        //Saves all changes made in this context to the underlying database.
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
