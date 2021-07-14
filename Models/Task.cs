using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Your task must hava a title")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = DateTime.Now; }
        }
        [Required(ErrorMessage = "End Date is Required!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        public float Estimate { get; set; }
        public State Status { get; set; }
        //Profile
        public ICollection<User> users { get; set; }
        //Constructor
        public Task()
        {
            StartDate = DateTime.Now;
        }

    }
}
