using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Snaleboda.XamarinForms.CustomControls;
using Snaleboda.XamarinForms.iOS.CustomRenderers;


[assembly: ExportRenderer(typeof(NewsListView), typeof(NewsListRenderer))]
namespace Snaleboda.XamarinForms.iOS.CustomRenderers
{
    public class NewsListRenderer : ListViewRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == "ItemsSource")
            {
                var control = (UITableView)Control;

                foreach(var cell in control.VisibleCells)
                {
                    //cell.BackgroundColor = "#FFE699";
                }
            }
        }
    }
}