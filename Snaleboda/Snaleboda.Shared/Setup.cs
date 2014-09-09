using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsCommon.Platform;
using Windows.UI.Xaml.Controls;
using Snaleboda.Library.Interfaces;
using System.Net.Http;
using Snaleboda.Utilities;

namespace Snaleboda
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new Library.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.RegisterType<HttpMessageHandler, HttpClientHandler>();
            Mvx.RegisterType<IHttpClientProvider, HttpClientProvider>();
            Mvx.RegisterType<ISerializer,JsonSerializer>();
#if WINDOWS_PHONE_APP
            Mvx.RegisterType<IPlatformSpecificsProvider,Utilities.PlatformSpecificsProvider>();
#endif
        }
    }
}