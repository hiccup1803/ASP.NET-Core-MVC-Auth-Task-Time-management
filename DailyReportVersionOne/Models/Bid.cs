namespace DailyReportVersionOne.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int Upwork {  get; set; }
        public int Freelancer { get; set; }
        public int Workana {  get; set; }
        public int Crowdwork {  get; set; }
        public int OtherSite {  get; set; }
        public DateOnly BidRecordDate { get; set; }
        public string UserName {  get; set; }
    }
}
