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
using Android.Graphics;
using Snaleboda.Xamarin.Core.Services;
using Android.Provider;
using Snaleboda.Xamarin.Core.Models;
using Java.IO;
using System.IO;

namespace Snaleboda.Xamarin.Droid
{
    [Activity(Label = "IncidentActivity")]
    public class IncidentActivity : Activity
    {
        int REQUEST_IMAGE_CAPTURE = 1;

        private ImageView image;
        private TextView name;
        private TextView description;
        private Button send;

        private ProgressBar progressBar;

        private Bitmap bitmap;

        private IncidentService incidentService;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.report);

            image = (ImageView)FindViewById(Resource.Id.image);
            image.Click += image_Click;

            send = (Button)FindViewById(Resource.Id.send);
            send.Click += send_Click;

            name = (TextView)FindViewById(Resource.Id.name);
            description = (TextView)FindViewById(Resource.Id.description);
            progressBar = (ProgressBar)FindViewById(Resource.Id.progressBar);

            incidentService = new IncidentService();
        }

        async void send_Click(object sender, EventArgs e)
        {
            progressBar.Visibility = ViewStates.Visible;
            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png,100,stream);
            var bytes = new byte[stream.Length];

            var i = stream.Read(bytes,0,(int)stream.Length);

            var imageString = UTF8Encoding.UTF8.GetString(bytes);

            var incident = new Incident()
            {
                Description = description.Text,
                Image = imageString
            };

            await incidentService.PostIncidentAsync(incident);

            progressBar.Visibility = ViewStates.Gone;
            Toast.MakeText(this, "Rapporten har skickats", ToastLength.Long).Show();

            description.Text = "";
            image.SetImageResource(Android.Resource.Drawable.IcMenuCamera);
            
        }

        void image_Click(object sender, EventArgs e)
        {
            Intent takePictureIntent = new Intent(MediaStore.ActionImageCapture);
            if (takePictureIntent.ResolveActivity(PackageManager) != null)
            {
                StartActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == Result.Ok)
            {
                Bundle extras = data.Extras;
                bitmap = (Bitmap)extras.Get("data");
                image.SetImageBitmap(bitmap);
            }
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