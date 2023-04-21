using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class Assessment
    {
        [DisplayName("Assessment ID")]
        public int AssessmentID { get; set; }
        [DisplayName("UserModules ID")]
        public int UserModulesID { get; set; }
        [Display(Name = "Student Email")]
        public string? StudentEmail { get; set; }
        [Display(Name = "Lecturer Email")]
        public string? LecturerEmailID { get; set; }
        public string? Grade { get; set; }
        [Display(Name = "File Name")]
        public string? FileName { get; set; }
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
        public virtual UserModules? UserModules { get; set; }
    }
}
