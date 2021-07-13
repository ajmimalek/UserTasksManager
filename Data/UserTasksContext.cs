using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserTasksManager.Models;

namespace UserTasksManager.Data
{
    public class UserTasksContext : DbContext
    {
        public UserTasksContext(DbContextOptions<UserTasksContext> opt) : base(opt)
        { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        
    }
}
