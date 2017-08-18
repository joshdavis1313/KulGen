using System.Threading.Tasks;
using MvvmCross.Platform;

namespace KulGen.Core
{
	public static class Setup
	{
		public static async Task SharedSetup()
		{
			var settings = await LocalSettings.LoadLocalSettings ();
			Mvx.RegisterSingleton<ILocalSettings> (settings);
		}
	}
}
