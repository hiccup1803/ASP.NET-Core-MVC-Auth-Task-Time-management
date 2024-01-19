using Microsoft.AspNetCore.Identity;

namespace DailyReportVersionOne.Models
{
    public class ApplicationRole :IdentityRole
    {
        public string? Description {  get; set; }
    }
}
