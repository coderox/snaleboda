using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;
using Snaleboda.Core.ViewModels;

namespace Snaleboda.Droid.Views
{
    [Activity(Label = "Menu")]
    public class MainView : MvxTabsFragmentActivity
    {
        public MainView()
            : base(Resource.Layout.MainView, Resource.Id.actualtabcontent)
        {
           
        }

        MainViewModel MainViewModel
        {
            get { return ViewModel as MainViewModel; }
        }

        protected override void AddTabs(Bundle args)
        {            
            AddTab<WelcomeFragment>("Welcome", "Welcome", args, MainViewModel);
            AddTab<NewsFragment>("News", "News", args, MainViewModel.News);
            AddTab<ContactsFragment>("Contacts", "Contacts", args, MainViewModel.Contacts);
        }
    }
}