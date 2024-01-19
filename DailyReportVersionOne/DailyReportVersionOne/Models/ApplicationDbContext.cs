using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DailyReportVersionOne.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Project>  Projects { get; set; }

        public DbSet<Study> Studies { get; set; }
    }
}
