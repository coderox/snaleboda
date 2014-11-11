using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Snaleboda.Xamarin.Core.Models;
using Snaleboda.Xamarin.Core.Services;

namespace Snaleboda.Xamarin.ios
{
	partial class NewsController : UITableViewController
	{
        private List<News> _news = new List<News>();

		public NewsController (IntPtr handle) : base (handle)
		{
		}

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var service = new NewsService();
            _news = await service.GetNewsAsync();
            this.TableView.ReloadData();
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _news.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _news[indexPath.Row];

            var cell = this.TableView.DequeueReusableCell("NewsCell") as NewsCell;
            cell.SetContent(item);
            return cell;
        }

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            int rowSize = 27;
            int titleSize = 70;
            int charsPerRow = 41;

            int retHeight = 0;
            int numOfChars = _news[indexPath.Row].Content.Length;//Total length of item text
            if (numOfChars > 200) numOfChars = 200;    //Content max initialized in viewdidload
            retHeight = numOfChars / charsPerRow;
            if (retHeight < 1) retHeight = 1;

            return (float)(retHeight * rowSize + titleSize);
        }
	}
}
