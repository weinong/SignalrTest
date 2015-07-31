using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.AspNet.SignalR.Client;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static HubConnection hub;
        private static IHubProxy proxy;
        public MainPage()
        {
            hub = new HubConnection("http://localhost:13442");
            proxy = hub.CreateHubProxy("MyHub");
            proxy.On<string>("ServerNotified", (message) =>
            {
                System.Diagnostics.Debug.WriteLine(message);
            });

            hub.Start().Wait();

            proxy.Invoke("NotifyServer");
            this.InitializeComponent();
        }
    }
}
