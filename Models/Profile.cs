using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserTasksManager.Models
{
    public enum Role
    {
        Developer,
        Manager
    }
    public class Profile : User
    {
        public Role role { get; set; }
        //Tasks
        public ICollection<Task> tasks { get; set; }

    }
}
