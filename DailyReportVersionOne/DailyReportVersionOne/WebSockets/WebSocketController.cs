using DailyReportVersionOne.Models;
using DailyReportVersionOne.WebSockets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Net.WebSockets;

namespace DailyReportVersionOne.WebSockets
{
    public class WebSocketController : Controller
    {
        private ChatHandler _chatHandler {  get; set; }
        private readonly string connectionUrl = "ws://localhost:5099/ws?username=";
        private SignInManager<ApplicationUser> _signInManager;

        public WebSocketController(ChatHandler chatHandler, SignInManager<ApplicationUser> signInManager)
        {
            _chatHandler = chatHandler;
            _signInManager = signInManager;
        }

    
        public void connectServer()
        {
            string _userName = _signInManager.Context.User.Identity.Name;

            var socket = new ClientWebSocket();

            socket.ConnectAsync(new Uri(connectionUrl + _userName), CancellationToken.None);
        }

    }
}
