using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AspNet4
{
    public class MyHub : Hub
    {
        public void NotifyServer()
        {
            Clients.Caller.ServerNotified("server notified");
        }
    }
}