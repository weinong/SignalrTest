using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hub = new HubConnection("http://localhost:13442");
            var proxy = hub.CreateHubProxy("MyHub");
            proxy.On("ServerNotified", (message) =>
            {
                Console.WriteLine((string)message);
            });

            hub.Start().Wait();

            proxy.Invoke("NotifyServer");

            Console.WriteLine("press any key to continue.");
            Console.ReadKey();
        }
    }
}
