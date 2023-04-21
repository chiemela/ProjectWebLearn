using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FullStack.Models
{
    public class Feedbacks
    {
        [Key]
        [Display(Name = "Feedbacks ID")]
        public int FeedbacksID { get; set; }
        [DisplayName("Modules ID")]
        public string? ModulesID { get; set; }
        [Required]
        [Display(Name = "Student Email")]
        public string? StudentEmailID { get; set; }
        [Required]
        [Display(Name = "Lecturer Email")]
        public string? LecturerEmailID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Grade")]
        public int Grade { get; set; }
        [Required]
        [Display(Name = "Lecturer Comment")]
        public string? LecturerComment { get; set; }
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
        public virtual Modules? Modules { get; set; }
    }
}