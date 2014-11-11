using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using Snaleboda.Xamarin.Core.Services;
using Snaleboda.Xamarin.Core.Models;
using System.Drawing;

namespace Snaleboda.Xamarin.ios
{
	partial class ReportController : UIViewController
	{
        UIImagePickerController _picker;

		public ReportController (IntPtr handle) : base (handle)
		{
		}

        partial void TakeImage_TouchUpInside(UIButton sender)
        {
            var picker = new UIImagePickerController();
            picker.AllowsEditing = true;
            picker.SourceType = UIImagePickerControllerSourceType.Camera;
            this.PresentViewController(picker, true, null);
        }

        partial void PickImage_TouchUpInside(UIButton sender)
        {
            _picker = new UIImagePickerController();
            _picker.AllowsEditing = true;
            _picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            _picker.FinishedPickingMedia += picker_FinishedPickingMedia;
            _picker.Canceled += picker_Canceled;
            this.PresentViewController(_picker, true, null);
        }

        void picker_Canceled(object sender, EventArgs e)
        {
            _picker.DismissViewController(true, null);
        }

        void picker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            imageView.Image = e.EditedImage; 
            _picker.DismissViewController(true, null);   
        }

        async partial void SendImage_TouchUpInside(UIButton sender)
        {
            var service = new IncidentService();
            var image = CompressForUpload(imageView.Image, 0.5f);
            var imageData = image.AsPNG();
            var encodedImage = imageData.GetBase64EncodedString(NSDataBase64EncodingOptions.None);

            var incident = new Incident()
            {
                Name = name.Text,
                Description = description.Text,
                Image = encodedImage
            };

            await service.PostIncidentAsync(incident);
        }

        private UIImage CompressForUpload(UIImage image, float scale)
        {
            var originalSize = image.Size;
            var newSize = new SizeF(originalSize.Width * scale, originalSize.Height * scale);

            UIGraphics.BeginImageContext(newSize);
            image.Draw(new RectangleF(0, 0, newSize.Width, newSize.Height));
            var newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return newImage;
        }
	}
}
