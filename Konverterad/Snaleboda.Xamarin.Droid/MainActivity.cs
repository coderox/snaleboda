using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Snaleboda.Xamarin.Droid
{
    [Activity(Label = "Snaleboda.Xamarin.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Resource.Id.action_contacts:
                    StartActivity(typeof(ContactActivity));
                    return true;
                case Resource.Id.action_news:
                    StartActivity(typeof(NewsActivity));
                    return true;
                case Resource.Id.action_report:
                    StartActivity(typeof(IncidentActivity));
                    return true;
                    
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

