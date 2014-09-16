using Autofac;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Services;
using Snaleboda.XamarinForms.Networking;
using Snaleboda.XamarinForms.Utilities;
using Snaleboda.XamarinForms.ViewModels;
using Snaleboda.XamarinForms.Views;
using System.Net.Http;

using Xamarin.Forms.Labs.Services;
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
            builder.RegisterType<ContactsViewModel>();
            builder.RegisterType<IncidentViewModel>();

            builder.RegisterType<NewsView>();
            builder.RegisterType<MainView>();
            builder.RegisterType<ContactsView>();
            builder.RegisterType<IncidentView>();

            builder.RegisterType<AsyncServiceAgent>().As<IAsyncServiceAgent>();
            builder.RegisterType<HttpClientProvider>().As<IHttpClientProvider>();
            builder.RegisterType<HttpClientHandler>().As<HttpMessageHandler>();
            builder.RegisterType<JsonSerializer>().As<ISerializer>();

            var container = builder.Build();

            Resolver.SetResolver(new AutofacResolver(container));
        }
    }
}