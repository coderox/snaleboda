using System;
using Android.App;
using Android.Content;
using Cirrious.CrossCore.Droid.Platform;
using Snaleboda.Library.Interfaces;

namespace Snaleboda.Droid.Utilities
{
    [Service]
    public class PlatformSpecificsProvider : MvxAndroidTask, IPlatformSpecificsProvider
    {
        public void PhoneCall(string number, string name)
        {
            var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", number));
            var intent = new Intent(Intent.ActionDial, uri);                      
            StartActivity(intent);
        }
    }
}