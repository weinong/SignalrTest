using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRConsoleApp
{
    public class Program
    {
        public void Main(string[] args)
        {
            var hub = new HubConnection("http://localhost:13442");
            var proxy = hub.CreateHubProxy("MyHub");
            proxy.On("ServerNotified", (message) =>
            {
                Trace.WriteLine((string)message);
            });

            hub.Start().Wait();

            proxy.Invoke("NotifyServer");

            Console.WriteLine("press any key to continue.");
            Console.ReadKey();
        }
    }
}
