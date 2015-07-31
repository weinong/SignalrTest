using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalrTest
{
    public class MyHub : Hub
    {
        public void NotifyServer()
        {
            Clients.Caller.ServerNotified("server notified");
        }
    }
}
