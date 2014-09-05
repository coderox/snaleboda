using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsCommon.Platform;
using Windows.UI.Xaml.Controls;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Utilities;

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

            Mvx.RegisterType<IHttpClientProvider, HttpClientProvider>();
        }
    }
}