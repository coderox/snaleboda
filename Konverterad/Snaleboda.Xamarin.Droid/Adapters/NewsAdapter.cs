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
using Snaleboda.Xamarin.Core.Models;
using Snaleboda.Xamarin.Core.Services;
using System.Threading.Tasks;

namespace Snaleboda.Xamarin.Droid.Adapters
{
    public class NewsAdapter : ArrayAdapter<News>
    {
        private NewsService _newsService;
        private List<News> _news;
        private Activity _context;

        public NewsAdapter(Activity context) : base(context,Resource.Layout.news_listitem)
        {
            _context = context;
            _newsService = new NewsService();
            Init();
        }

        public async Task Init()
        {
            _news = await _newsService.GetNewsAsync();
            AddAll(_news);
            NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View rowView = convertView;
            ViewHolder holder;

            if (rowView == null)
            {
                LayoutInflater inflater = _context.LayoutInflater;
                rowView = inflater.Inflate(Resource.Layout.news_listitem, null);
                holder = new ViewHolder();
                holder.Title = (TextView)rowView.FindViewById(Resource.Id.title);
                holder.Info = (TextView)rowView.FindViewById(Resource.Id.info);
                rowView.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)rowView.Tag;
            }

            holder.Title.Text = _news[position].Title;
            holder.Info.Text = _news[position].Content;

            return rowView;
        }

        private class ViewHolder : Java.Lang.Object
        {
            public TextView Title {get;set;}
            public TextView Info {get;set;}
        }
    }
}