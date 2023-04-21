using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class UserModules
    {
        [Key]
        [Display(Name = "User Enrolled Modules")]
        public int UserModulesID { get; set; }
        [Display(Name = "Modules ID")]
        public int ModuleID { get; set; }
        [Display(Name = "Enrollment ID")]
        public int EnrollmentID { get; set; }
        public virtual Module? Module { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
    }
}