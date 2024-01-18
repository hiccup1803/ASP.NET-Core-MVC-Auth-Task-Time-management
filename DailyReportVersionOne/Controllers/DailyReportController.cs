using Microsoft.AspNetCore.Mvc;
using DailyReportVersionOne.Models;
namespace DailyReportVersionOne.Controllers
{
    public class DailyReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateReport()
        {
            return View();
        }

      

    }
}
