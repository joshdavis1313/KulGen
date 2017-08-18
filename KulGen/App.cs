using KulGen.Source.ViewModels.CombatTracker;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace KulGen
{
	public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<CombatTrackerViewModel>();
        }
    }
}
