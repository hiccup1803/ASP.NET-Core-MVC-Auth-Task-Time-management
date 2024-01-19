using DailyReportVersionOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Diagnostics;

namespace DailyReportVersionOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Dashboard/Id")]
        public IActionResult Dashboard(string id)
        {
            var currentDate = DateTime.Parse(id).Date;
            DashboardViewModel model = new DashboardViewModel();
            var ProjectResult = _context.Projects.Where(p => (p.ProjectRecordDate.Date == currentDate));
            var BidResult = _context.Bids.Where(p => p.BidRecordDate.Date == currentDate);
            var StudyResult = _context.Studies.Where(p => p.StudyRecordDate.Date == currentDate);
            model.Projects = ProjectResult.ToArray();
            model.Bids = BidResult.ToArray();
            model.Studies = StudyResult.ToArray();
            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
