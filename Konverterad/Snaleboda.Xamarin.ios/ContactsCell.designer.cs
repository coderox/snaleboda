// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Snaleboda.Xamarin.ios
{
	[Register ("ContactsCell")]
	partial class ContactsCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Email { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Name { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Phone { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Email != null) {
				Email.Dispose ();
				Email = null;
			}
			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}
			if (Phone != null) {
				Phone.Dispose ();
				Phone = null;
			}
		}
	}
}
