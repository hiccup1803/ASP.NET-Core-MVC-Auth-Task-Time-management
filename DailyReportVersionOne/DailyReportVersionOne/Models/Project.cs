using System.ComponentModel.DataAnnotations;
namespace DailyReportVersionOne.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
       
        public string? ProjectName { get; set; }
        [Required]
        [Range(0, 20000)]
        public int ProjectPrice { get; set; }
        [Required]
        public string? ClientCountry { get; set; }
        [Required]
        [Range(0, 100)]
        public int ProjectState { get; set; }
        [Required]
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectRecordDate { get; set;}
        public string? UserName { get; set; }
    }
}
