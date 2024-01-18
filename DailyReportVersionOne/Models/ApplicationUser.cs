using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DailyReportVersionOne.Models
{
    public class ApplicationUser:IdentityUser
    {
      
        public string? Description {  get; set; }
    }
}
