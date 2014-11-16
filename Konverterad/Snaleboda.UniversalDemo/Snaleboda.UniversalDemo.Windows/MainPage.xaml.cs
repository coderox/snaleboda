using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Navigation;
using Snaleboda.UniversalDemo.SampleData;
using Snaleboda.UniversalDemo.ViewModels;

namespace Snaleboda.UniversalDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageVm _vm;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = _vm = new MainPageVmSampleData();
            //DataContext = _vm = new MainPageVm();
            await _vm.InitAsync();
            base.OnNavigatedTo(e);
        }
    }
}
