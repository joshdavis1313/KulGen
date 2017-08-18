using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace KulGen.Droid.Source.Views
{
	[Activity(
		Label = "App Of Many Things"
		, MainLauncher = true
        , Icon = "@drawable/icon_main"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen() : base(Resource.Layout.SplashScreen)
		{
		}
	}
}
