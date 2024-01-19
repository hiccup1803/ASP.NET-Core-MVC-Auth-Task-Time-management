using System.ComponentModel.DataAnnotations;

namespace DailyReportVersionOne.Models
{
    public class Bid
    {
        public int Id { get; set; }
        [Required]
        public int Upwork {  get; set; }
        [Required]
        public int Freelancer { get; set; }
        [Required]
        public int Workana {  get; set; }
        [Required]
        public int Crowdwork {  get; set; }
        [Required]
        public int OtherSite {  get; set; }
        public DateTime BidRecordDate { get; set; }
        public string? UserName {  get; set; }
    }
}
