using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Snaleboda.Library;

namespace Snaleboda
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                // Production
                //var serviceAgent = new ServiceAgent();

                // Faking the http stack
                //var serviceAgent = new ServiceAgent(new FakeHttpClientProvider());

                // Faking the service implementation
                var serviceAgent = new FakeServiceAgent();

                var newsTask = serviceAgent.GetNewsAsync();
                var contactsTask = serviceAgent.GetContactsAsync();

                await Task.WhenAll(newsTask, contactsTask);

                if (newsTask.Result != null)
                {
                    newsCollection.Source = newsTask.Result;
                }

                if (contactsTask.Result != null)
                {
                    foreach (var contactItem in contactsTask.Result)
                    {

                    }
                }

            }catch {}

        }
    }
}
