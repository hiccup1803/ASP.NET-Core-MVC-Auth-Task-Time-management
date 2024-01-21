using System.Text.Json;
using WebSocketManager.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DailyReportVersionOne.WebSockets
{
    public class ServerMessage
    {
        public ServerMessage()
        {
            Users = new List<string>();
        }

        public ServerMessage(MessageType messageType, string messageContent, List<string> users)
        {
            Type = messageType.ToString();
            Content = messageContent;
            Users = users;
        }

        public ServerMessage(ClientMessage clientMessage)
        {
            Type = clientMessage.GetMessageType();
            Content = clientMessage.BuildChatMessageBody();
        }

        public ServerMessage(string username, bool isDisconnect, List<string> users)
        {
            Type = MessageType.CONNECTION.ToString();
            Content = this.BuildConnectionMessageBody(username, isDisconnect);
            Users = users;
        }

        public string Type { get; set; }
        public string Content { get; set; }
        public List<string> Users { get; set; }

        private string BuildConnectionMessageBody(string username, bool isDisconnect)
        {

            if (isDisconnect)
            {
                var data1 = new
                {
                    username = username,
                    state = "left"
                };
                string data = JsonSerializer.Serialize(data1);
                return data;
            }
            else
            {
                var data1 = new
                {
                    username = username,
                    state = "join"
                };
                string data = JsonSerializer.Serialize(data1);
                return data;
            }
        }
    }
}
