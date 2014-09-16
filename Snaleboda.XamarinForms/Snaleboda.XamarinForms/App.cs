using Snaleboda.XamarinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services;



namespace Snaleboda.XamarinForms
{
    public class App
    {
        public static Page GetMainPage()
        {
            var view = Resolver.Resolve<MainView>();

            return new NavigationPage(view);
        }
    }
}
