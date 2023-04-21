using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FullStack.Models
{
    public class Modules
    {
        [Key]
        [DisplayName("Modules ID")]
        public string? ModulesID { get; set; }
        [Required]
        [DisplayName("Module specification")]
        public string? ModuleSpecification { get; set; }
        [Required]
        [DisplayName("Module title")]
        public string? ModuleTitle { get; set; }
        [Required]
        [DisplayName("Module level")]
        public string? ModuleLevel { get; set; }
        [Required]
        [DisplayName("Credit rating")]
        public string? CreditRating { get; set; }
        [Required]
        [DisplayName("School")]
        public string? School { get; set; }
        [Required]
        [DisplayName("Total study hours")]
        public string? TotalStudyHours { get; set; }
        [Required]
        [DisplayName("Module summary")]
        public string? ModuleSummary { get; set; }
        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}
