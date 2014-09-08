using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Navigation;

namespace Snaleboda.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
#if WINDOWS_PHONE_APP
            await StatusBar.GetForCurrentView().HideAsync();
#endif
            base.OnNavigatedTo(e);
        }
    }
}
