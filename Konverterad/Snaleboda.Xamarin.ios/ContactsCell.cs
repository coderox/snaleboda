using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Snaleboda.Xamarin.ios
{
	partial class ContactsCell : UITableViewCell
	{
		public ContactsCell (IntPtr handle) : base (handle)
		{
		}

        public void SetContent(Core.Models.Contact item)
        {
            this.Name.Text = item.Name;
            this.Phone.Text = item.Phone;
            this.Email.Text = item.Email;
        }
    }
}
