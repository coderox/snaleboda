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
	[Register ("ReportController")]
	partial class ReportController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView description { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField name { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PickImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SendImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TakeImage { get; set; }

		[Action ("PickImage_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PickImage_TouchUpInside (UIButton sender);

		[Action ("SendImage_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SendImage_TouchUpInside (UIButton sender);

		[Action ("TakeImage_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void TakeImage_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (description != null) {
				description.Dispose ();
				description = null;
			}
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}
			if (name != null) {
				name.Dispose ();
				name = null;
			}
			if (PickImage != null) {
				PickImage.Dispose ();
				PickImage = null;
			}
			if (SendImage != null) {
				SendImage.Dispose ();
				SendImage = null;
			}
			if (TakeImage != null) {
				TakeImage.Dispose ();
				TakeImage = null;
			}
		}
	}
}
