using Microsoft.AspNetCore.Mvc;
using DailyReportVersionOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace DailyReportVersionOne.Controllers
{
    public class DailyReportController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public DailyReportController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateReport()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportViewModel reportModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var UserName = user.UserName;
                var CurrentDate = DateTime.Now;
                var result = await _context.Projects.FirstOrDefaultAsync(p => p.UserName == UserName && p.ProjectRecordDate.Date == DateTime.Today);
                if (result == null)
                {
                    var AddProject = new Project();
                    AddProject = reportModel.MyProject;
                    AddProject.UserName = UserName;
                    AddProject.ProjectRecordDate = CurrentDate;
                    _context.Projects.Add(AddProject);
                    var AddBid = new Bid();
                    AddBid = reportModel.MyBid;
                    AddBid.UserName = UserName;
                    AddBid.BidRecordDate = CurrentDate;
                    _context.Bids.Add(AddBid);
                    var AddStudy = new Study();
                    AddStudy = reportModel.Study;
                    AddStudy.UserName = UserName;
                    AddStudy.StudyRecordDate = CurrentDate;
                    _context.Studies.Add(AddStudy);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                   
                }
                ViewBag.ErrorMessage = $"You already reported today!!!";
                return View();
            }

            return View();
        }
    }
}
