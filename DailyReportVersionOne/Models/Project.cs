namespace DailyReportVersionOne.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string? ProjectName { get; set; }
        public int ProjectPrice { get; set; }
        public string? ClientCountry { get; set; }
        public int ProjectState { get; set; }
        public DateOnly ProjectStartDate {get; set;}
        public DateOnly ProjectRecordDate { get; set;}
        public string UserName { get; set; }
    }
}
