using System.Net.Http;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Droid.Utilities;
using Snaleboda.Library.Interfaces;

namespace Snaleboda.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Snaleboda.Library.App();
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
        }
    }
}