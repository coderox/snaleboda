using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;

namespace Snaleboda.Droid.Views
{
    [Activity(Label = "Menu", Theme = "@style/Theme.Main")]
    public class MainView : MvxTabsFragmentActivity
    {
        public MainView()
            : base(Resource.Layout.MainView, Resource.Id.actualtabcontent)
        {
        }

        protected override void AddTabs(Bundle args)
        {
            
            AddTab<WelcomeFragment>("Welcome", "Welcome", args, ViewModel);
            AddTab<NewsFragment>("News", "News", args, ViewModel);
            AddTab<ContactsFragment>("Contacts", "Contacts", args, ViewModel);
        }
    }
}