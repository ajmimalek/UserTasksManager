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
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetUserTasks(User user);
        IEnumerable<User> GetUsersByRole(Role role);
        Task GetTaskByTitle(string title);
        IEnumerable<Task> GetTasksByStatus(State state);
        //POST
        User AddUser(User user);
        Task AddTask(Task task);
        IEnumerable<Task> AddTasksToUser(User user, IEnumerable<Task> tasks);
        IEnumerable<Task> AddTasksToUser(string username, IEnumerable<Task> tasks);
        //PUT
        //PATCH
    }
}
