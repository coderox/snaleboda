using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Snaleboda.Xamarin.Core.Models;
using Snaleboda.Xamarin.Core.Services;

namespace Snaleboda.Xamarin.ios
{
	partial class ContactsController : UITableViewController
	{
        private List<Contact> _contacts = new List<Contact>();

		public ContactsController (IntPtr handle) : base (handle)
		{
		}

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var service = new ContactService();
            _contacts = await service.GetContactsAsync();
            this.TableView.ReloadData();
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _contacts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _contacts[indexPath.Row];

            var cell = this.TableView.DequeueReusableCell("ContactsCell") as ContactsCell;
            cell.SetContent(item);
            return cell;
        }

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 130;
        }
	}
}
