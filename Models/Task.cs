using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Your task must hava a title")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = DateTime.Now; }
        }
        [Required(ErrorMessage = "End Date is Required!")]
        [DataType(DataType.Date)]
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
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        public float Estimate { get; set; }
        public State Status { get; set; }
        //Profile
        public ICollection<Profile> profiles { get; set; }
    }
}
