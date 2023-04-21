using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class Feedback
    {
        [Display(Name = "Feedback ID")]
        public int FeedbackID { get; set; }
        [DisplayName("UserModules ID")]
        public int UserModulesID { get; set; }
        [Display(Name = "Student Email")]
        public string? StudentEmailID { get; set; }
        [Display(Name = "Lecturer Email")]
        public string? LecturerEmailID { get; set; }
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Display(Name = "Remark")]
        public string? Remark { get; set; }
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
        public virtual UserModules? UserModules { get; set; }
    }
}