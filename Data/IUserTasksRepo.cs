using System;
using System.Collections.Generic;
using UserTasksManager.Models;
using static UserTasksManager.Models.Task;

namespace UserTasksManager.Data
{
    public interface IUserTasksRepo
    {
        bool SaveChanges();
        //GET
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetUserTasks(User user);
        IEnumerable<User> GetUsersByRole(Role role);
        Task GetTaskByTitle(string title);
        IEnumerable<Task> GetTasksByStatus(State state);
        //POST
        User AddUser(User user);
        Task AddTask(Task task);
        //PATCH
        User AddTasksToUser(User user, IEnumerable<Task> tasks);
        User AddTasksToUser(Guid id, IEnumerable<Task> tasks);
        
    }
}
