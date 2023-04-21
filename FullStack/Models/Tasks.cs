using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class Tasks
    {
        [Key]
        [Display(Name = "Tasks ID")]
        public int TasksID { get; set; }
        [DisplayName("UserModules ID")]
        public int UserModulesID { get; set; }
        [Display(Name = "User Email")]
        public string? EmailID { get; set; }
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Status")]
        public string? Status { get; set; }
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
        public virtual UserModules? UserModules { get; set; }
    }
}