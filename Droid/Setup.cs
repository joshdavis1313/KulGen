using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.FieldBinding;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Platform;

namespace KulGen.Droid
{
	public class Setup : MvxAndroidSetup
	{
		Context AppContext;

		public static INC<bool> SetupComplete { get; } = new NC<bool> ();

		public Setup(Context applicationContext) : base(applicationContext)
		{
			AppContext = applicationContext;
		}

		protected override async void InitializeIoC()
		{
			base.InitializeIoC ();

			CurrentPlatform.Init ();

			await Core.Setup.SharedSetup ();

			SetupComplete.Value = true;
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
