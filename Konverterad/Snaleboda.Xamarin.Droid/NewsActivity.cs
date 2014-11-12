using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Snaleboda.Xamarin.Droid.Adapters;

namespace Snaleboda.Xamarin.Droid
{
    [Activity(Label = "NewsActivity")]
    public class NewsActivity : ListActivity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.list);

            var adapter = new NewsAdapter(this);
            ListAdapter = adapter;
            adapter.Init();

            this.ListView.ItemClick += ListView_ItemClick;
        }

        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
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