using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class UserModule
    {
        [Key]
        [Display(Name = "User Enrolled Modules")]
        public int UserModulesID { get; set; }
        [Display(Name = "Modules ID")]
        public string? ModulesID { get; set; }
        [Display(Name = "Enrollment ID")]
        public int EnrollmentID { get; set; }
        public virtual Modules? Modules { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
    }
}