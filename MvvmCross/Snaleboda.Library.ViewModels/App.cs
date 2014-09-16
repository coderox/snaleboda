using System;
using System.Reflection;
using Cirrious.CrossCore.IoC;
using Snaleboda.Library.Services;

namespace Snaleboda.Library
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            typeof(AsyncServiceAgent).GetTypeInfo().Assembly.CreatableTypes()
                .EndingWith("Agent")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Mvx.RegisterType<IAsyncServiceAgent, AsyncServiceAgent>();
            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}