using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class Module
    {
        [Key]
        [DisplayName("Module ID")]
        public int ModuleID { get; set; }
        [Required]
        [DisplayName("Module Code")]
        public string? Code { get; set; }
        [Required]
        [DisplayName("Module Name")]
        public string? Name { get; set; }
        [DisplayName("Credit Rating")]
        public string? CreditRating { get; set; }
        [DisplayName("School")]
        public string? School { get; set; }
        [DisplayName("Total Study Hours")]
        public string? TotalStudyHours { get; set; }
        [DisplayName("Module Description")]
        public string? Description { get; set; }
        [Required]
        [DisplayName("Duration In Weeks")]
        public int DurationInWeeks { get; set; }
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;

        //public virtual ICollection<AspNetUsers>? User { get; set; }
    }
}
