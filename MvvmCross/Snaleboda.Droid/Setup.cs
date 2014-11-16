using System.Net.Http;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Droid.Utilities;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Services;
using Snaleboda.Core.ViewModels;

namespace Snaleboda.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Snaleboda.Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.RegisterType<HttpMessageHandler,ModernHttpClient.NativeMessageHandler>();            
            Mvx.RegisterType<IHttpClientProvider, HttpClientProvider>();
            Mvx.RegisterType<IPlatformSpecificsProvider, PlatformSpecificsProvider>();
            Mvx.RegisterType<IAsyncServiceAgent, AsyncServiceAgent>();

            Mvx.RegisterType<ISerializer, JsonSerializer>();

            Mvx.RegisterType<MainViewModel, MainViewModel>();
            Mvx.RegisterType<NewsViewModel, NewsViewModel>();
            Mvx.RegisterType<ContactsViewModel, ContactsViewModel>();
            Mvx.RegisterType<ContactViewModel, ContactViewModel>();
        }
    }
}