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
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> AddTasksToUser(User user, IEnumerable<Models.Task> tasks)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> AddTasksToUser(string username, IEnumerable<Models.Task> tasks)
        {
            throw new NotImplementedException();
        }

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        //GET
        public Models.Task GetTaskByTitle(string title)
        {
            //FirstOrDefault : LINQ Operation
            return _context.Tasks.FirstOrDefault(t => t.Title.Equals(title));
        }

        public IEnumerable<Models.Task> GetTasks()
        {
            //ToList : LINQ Operation
            return _context.Tasks.ToList();
        }

        public IEnumerable<Models.Task> GetTasksBeforeEndDate(DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetTasksByStatus(Models.Task.State state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetUsersByRole(Role role)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetUserTasks(User user)
        {
            throw new NotImplementedException();
        }
    }
}
