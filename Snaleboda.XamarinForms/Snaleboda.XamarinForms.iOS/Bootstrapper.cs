using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms.Labs.Services;
using Snaleboda.XamarinForms.ViewModels;
using Snaleboda.XamarinForms.Views;
using Autofac;
using Xamarin.Forms.Labs.Services.Autofac;


namespace Snaleboda.XamarinForms.iOS
{
    public class Bootstrapper
    {
        public static void Init()
        {
           var builder = new ContainerBuilder();
           
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<NewsViewModel>();

            builder.RegisterType<NewsView>();
            builder.RegisterType<MainView>();
            builder.RegisterType<NewsView>();
            builder.RegisterType<ContactsView>();

            var container = builder.Build();

            Resolver.SetResolver(new AutofacResolver(container));

        }
    }
}