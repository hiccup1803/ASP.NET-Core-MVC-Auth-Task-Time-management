using Microsoft.AspNetCore.Mvc;
using DailyReportVersionOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Net.WebSockets;
using System;
using DailyReportVersionOne.WebSockets;
using System.Text.Json;
using System.Text;
using System.Threading;
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
                    var newProject = new Project();
                    newProject = reportModel.MyProject;
                    newProject.UserName = UserName;
                    newProject.ProjectRecordDate = CurrentDate;
                    _context.Projects.Add(newProject);
                    var newBid = new Bid();
                    newBid = reportModel.MyBid;
                    newBid.UserName = UserName;
                    newBid.BidRecordDate = CurrentDate;
                    _context.Bids.Add(newBid);
                    var newStudy = new Study();
                    newStudy = reportModel.Study;
                    newStudy.UserName = UserName;
                    newStudy.StudyRecordDate = CurrentDate;
                    _context.Studies.Add(newStudy);
                    _context.SaveChanges();


                    //var socket = new WebSocket(connectionUrl + UserName);
                    string connectionUrl = "ws://localhost:5099/ws?username=";
                    var socket = new ClientWebSocket();
                    await socket.ConnectAsync(new Uri(connectionUrl + UserName), CancellationToken.None);
                    //string data = "Here DailyReport Newly Added!!!";
                    var data1 = new { username = UserName, 
                        projectName = newProject.ProjectName,
                        projectPrice = newProject.ProjectPrice,
                        clientCountry = newProject.ClientCountry,
                        projectState = newProject.ProjectState, 
                        projectStatrtDate = newProject.ProjectStartDate,
                        upwork = newBid.Upwork,
                        freelancer = newBid.Freelancer,
                        workana = newBid.Workana,
                        crowdwork = newBid.Crowdwork,
                        othersite = newBid.OtherSite,
                        studyDescription = newStudy.Description
                    };
                    string data = JsonSerializer.Serialize(data1);
                    ClientMessage message = new ClientMessage();
                    message.Type = "chat";
                    message.Sender = UserName;
                    message.Content = data;
                    message.Receiver = "Everybody";
                    message.IsPrivate = false;

                    string json = JsonSerializer.Serialize(message);

                    byte[] bytes = Encoding.UTF8.GetBytes(json);

                    await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                    statusDescription: "ConnectionClosed",
                                    cancellationToken: CancellationToken.None);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorMessage = $"Again";
                return View();
            }

            return View();
        }
    }
}
