using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Snaleboda.Xamarin.ios
{
	partial class NewsCell : UITableViewCell
	{
		public NewsCell (IntPtr handle) : base (handle)
		{
		}

        public void SetContent(Core.Models.News item)
        {
            titleLabel.Text = item.Title;
            newsText.Text = item.Content.Length > 200 ? item.Content.Substring(0, 200) + "..." : item.Content;
        }
    }
}
