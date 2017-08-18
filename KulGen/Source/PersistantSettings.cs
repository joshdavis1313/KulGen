using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace KulGen
{
    public static class PersistantSettings
	{
		static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		const string PlayerIdKey = "playerid_key";
		static readonly string PlayerIdDefault = "";

		public static string PlayerId
		{
			get { return AppSettings.GetValueOrDefault(PlayerIdKey, PlayerIdDefault); }
			set { AppSettings.AddOrUpdateValue(PlayerIdKey, value); }
		}
    }
}
