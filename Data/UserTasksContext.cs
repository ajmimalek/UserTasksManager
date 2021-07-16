using Microsoft.EntityFrameworkCore;
using System;
using UserTasksManager.Models;

namespace UserTasksManager.Data
{
    public class UserTasksContext : DbContext
    {
        public UserTasksContext(DbContextOptions<UserTasksContext> opt) : base(opt)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        //Seeding Data when runing the application
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "ajmimalek",
                    Password = "malek123",
                    ConfirmPassword = "malek123",
                    DateCreated = DateTime.Now,
                    Email = "malek.ajmi@se.linedata.com",
                    role = Role.Developer
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "adeladel",
                    Password = "adel336",
                    ConfirmPassword = "adel336",
                    Email = "adel.adel@se.linedata.com",
                    role = Role.Manager
                }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task()
                {
                    Id = Guid.NewGuid(),
                    Title = "Creating a new Project",
                    Description = "Create a project",
                    EndDate = DateTime.Now.AddDays(1),
                    Estimate = 5.12F,
                    Status = Task.State.ToDO
                },
                new Task()
                {
                    Id = Guid.NewGuid(),
                    Title = "Class Modeling",
                    Description = "Adding Classes to Project",
                    EndDate = DateTime.Now.AddDays(3),
                    Estimate = 3.2F,
                    Status = Task.State.ToDO
                }) ; 
        }
    }
}
