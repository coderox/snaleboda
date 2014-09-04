using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Snaleboda.Library.Services;
using Snaleboda.Library.Utilities;

namespace Snaleboda
{
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
                await LoadAsync();
                //Load();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Load()
        {
            try
            {
                // Production
                //var serviceAgent = new ServiceAgent();

                // Faking the http stack
                //var serviceAgent = new ServiceAgent(new FakeHttpClientProvider());

                // Faking the service implementation
                var serviceAgent = new FakeServiceAgent();

                serviceAgent.GetNews(result => Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (result != null)
                    {
                        newsCollection.Source = result;
                    }
                }));

                serviceAgent.GetContacts(result => Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (result != null)
                    {
                        contactsCollection.Source = result;
                    }
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task LoadAsync()
        {
            try
            {
                // Production
                //var serviceAgent = new AsyncServiceAgent();

                // Faking the http stack
                var serviceAgent = new AsyncServiceAgent(new FakeHttpClientProvider());

                // Faking the service implementation
                //var serviceAgent = new FakeAsyncServiceAgent();

                var newsTask = serviceAgent.GetNewsAsync();
                var contactsTask = serviceAgent.GetContactsAsync();

                await Task.WhenAll(newsTask, contactsTask);

                if (newsTask.Result != null)
                {
                    newsCollection.Source = newsTask.Result;
                }

                if (contactsTask.Result != null)
                {
                    contactsCollection.Source = contactsTask.Result;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
