namespace DailyReportVersionOne.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string? ProjectName { get; set; }
        public int ProjectPrice { get; set; }
        public string? ClientCountry { get; set; }
        public int ProjectState { get; set; }
        public DateTime ProjectStartDate {get; set;}
        public DateTime ProjectRecordDate { get; set;}
        public string? UserName { get; set; }
    }
}
