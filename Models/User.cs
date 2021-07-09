using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserTasksManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 5 || value.Length > 20)
                {
                    Console.WriteLine("Votre mot de passe doit contenir entre 5 et 20 caractéres");
                }
                else
                {
                    password = value;
                }
            }
        }
        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value.Equals(Password))
                {
                    confirmPassword = value;
                }
                else
                {
                    Console.WriteLine("Les deux mdp sont pas identiques");
                }
            }
        }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
