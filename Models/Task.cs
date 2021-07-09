using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace UserTasksManager.Models
{
    public class Task
    {
        public enum State
        {
            ToDO,
            InDevelopment,
            InCodeReview,
            Testing,
            Done
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        private string startDate;

        public string StartDate
        {
            get { return startDate; }
            set { startDate = DateTime.Now.ToString(); }
        }
        private string endDate;

        public string EndDate
        {
            get { return endDate; }
            set
            {
                DateTime parsedDate;
                var isValidFormat = DateTime.TryParseExact(value,"MM/dd/yyyy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out parsedDate);
                if (isValidFormat)
                {
                    endDate = value;
                }
                else
                {
                    endDate = "Invalid";
                }
            }
        }
        public float Estimate { get; set; }
        public State Status { get; set; }
        //Profile
        public ICollection<Profile> profiles { get; set; }
    }
}
