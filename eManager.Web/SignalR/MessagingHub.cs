using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace eManager.Web
{
    public class MessagingHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessageToPage(message);
        }
    }
}