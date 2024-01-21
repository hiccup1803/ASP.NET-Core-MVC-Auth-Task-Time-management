namespace DailyReportVersionOne.Models
{
    public class DashboardViewModel
    {
        public Project[]? Projects { get; set; }
        public Bid[]? Bids { get; set; }
        public Study[]? Studies { get; set; }

        public DateTime DisplayDate { get; set; }
    }
}
