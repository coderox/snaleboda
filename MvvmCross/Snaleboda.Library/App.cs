using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Utilities;

namespace Snaleboda.Library
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Agent")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}