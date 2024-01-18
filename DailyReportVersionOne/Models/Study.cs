namespace DailyReportVersionOne.Models
{
    public class Study
    {
        public int Id { get; set; }
        public string? Description {get; set; }
        public DateOnly StudyRecordDate {  get; set; }
    }
}
