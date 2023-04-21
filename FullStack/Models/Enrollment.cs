using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class Enrollment
    {
        [Key]
        [Display(Name = "Enrollment ID")]
        public int EnrollmentID { get; set; }
        [Display(Name = "User Email")]
        public string? EmailID { get; set; }
        /*
         [Display(Name = "User ID")]
        public string? UserID { get; set; }
         */
        /*
        [Display(Name = "User ID")]
        public string? UserID { get; set; }
        */
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}