namespace DailyReportVersionOne.Models
{
    public class Study
    {
        public int Id { get; set; }
        public string? Description {get; set; }
        public DateTime StudyRecordDate {  get; set; }

        public string? UserName {  get; set; }
    }
}
